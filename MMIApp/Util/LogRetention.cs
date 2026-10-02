using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MMI
{
    // Deletes log files older than the keep period set on System Data.
    //
    // MMI owns the clean-up for both programs: it walks the folders in
    // CSystemConfig.LogFolders, which by default hold the MMI logs and the SEQ
    // sequence, error and lot logs, and deletes the log files last written
    // before the cut-off. Only log extensions are touched, and a folder is
    // removed only once it is empty and was created before the cut-off, so a
    // folder a writer has just made for today is never taken from under it.
    //
    // The purge runs a minute after start-up, then every hour, and when the
    // keep period is applied on System Data.
    static class CLogRetention
    {
        private static readonly string[] LogExtensions = { ".log", ".txt" };

        private static readonly TimeSpan FirstRunDelay = TimeSpan.FromMinutes(1);
        private static readonly TimeSpan RunInterval   = TimeSpan.FromHours(1);

        private static System.Threading.Timer timer;
        private static int nRunning = 0;

        public sealed class Result
        {
            public int FilesDeleted;
            public int FoldersDeleted;
            public int Failures;
            public long BytesFreed;
            public DateTime CutOff;
        }

        public static void Start()
        {
            if (timer != null) return;
            timer = new System.Threading.Timer(_ => PurgeAndLog(), null, FirstRunDelay, RunInterval);
        }

        public static void Stop()
        {
            System.Threading.Timer t = timer;
            timer = null;
            if (t != null) t.Dispose();
        }

        // Runs one purge with the current settings and writes what it did to
        // the MMI log. Returns null when a purge was already running.
        public static Result PurgeAndLog()
        {
            if (Interlocked.Exchange(ref nRunning, 1) == 1) return null;
            try
            {
                Result r = Purge(DateTime.Now, CSystemConfig.LogKeepDays, Folders());
                if (r.FilesDeleted > 0 || r.FoldersDeleted > 0 || r.Failures > 0)
                {
                    CThreadMMILog.GetInstance.AddMMILog(string.Format(
                        "Log retention: {0} files ({1:N0} KB) and {2} folders older than {3:yyyy-MM-dd} deleted, {4} could not be deleted",
                        r.FilesDeleted, r.BytesFreed / 1024, r.FoldersDeleted, r.CutOff, r.Failures));
                }
                return r;
            }
            finally
            {
                Interlocked.Exchange(ref nRunning, 0);
            }
        }

        // The folders to walk, made absolute, without repeats and without any
        // drive root: a mistyped setting must not let the purge loose on C:\.
        public static List<string> Folders()
        {
            List<string> list = new List<string>();
            foreach (string strPart in (CSystemConfig.LogFolders ?? "").Split(';'))
            {
                string strFolder = strPart.Trim();
                if (strFolder.Length == 0) continue;
                try
                {
                    strFolder = Path.GetFullPath(strFolder).TrimEnd('\\');
                }
                catch (Exception)
                {
                    continue;
                }
                string strRoot = Path.GetPathRoot(strFolder + "\\");
                if (string.Equals(strFolder + "\\", strRoot, StringComparison.OrdinalIgnoreCase)) continue;
                if (list.Exists(f => string.Equals(f, strFolder, StringComparison.OrdinalIgnoreCase))) continue;
                list.Add(strFolder);
            }
            return list;
        }

        // Today and the nKeepDays days before it are kept.
        public static DateTime CutOffFor(DateTime now, int nKeepDays)
        {
            return now.Date.AddDays(-nKeepDays);
        }

        public static Result Purge(DateTime now, int nKeepDays, IEnumerable<string> folders)
        {
            Result r = new Result { CutOff = CutOffFor(now, nKeepDays) };
            foreach (string strFolder in folders)
            {
                if (!Directory.Exists(strFolder)) continue;
                PurgeFolder(new DirectoryInfo(strFolder), r, true);
            }
            return r;
        }

        private static void PurgeFolder(DirectoryInfo dir, Result r, bool bIsRoot)
        {
            DirectoryInfo[] subDirs;
            FileInfo[] files;
            try
            {
                subDirs = dir.GetDirectories();
                files = dir.GetFiles();
            }
            catch (Exception)
            {
                r.Failures++;
                return;
            }

            foreach (DirectoryInfo sub in subDirs)
            {
                // A junction could lead out of the log folder.
                if ((sub.Attributes & FileAttributes.ReparsePoint) != 0) continue;
                PurgeFolder(sub, r, false);
            }

            foreach (FileInfo file in files)
            {
                if (!IsLogFile(file.Name)) continue;
                if (file.LastWriteTime >= r.CutOff) continue;
                try
                {
                    long nLength = file.Length;
                    if ((file.Attributes & FileAttributes.ReadOnly) != 0)
                    {
                        file.Attributes = FileAttributes.Normal;
                    }
                    file.Delete();
                    r.FilesDeleted++;
                    r.BytesFreed += nLength;
                }
                catch (Exception)
                {
                    // Still open by its writer, or locked by a viewer.
                    r.Failures++;
                }
            }

            if (bIsRoot) return;
            try
            {
                dir.Refresh();
                if (dir.CreationTime < r.CutOff && dir.GetFileSystemInfos().Length == 0)
                {
                    dir.Delete(false);
                    r.FoldersDeleted++;
                }
            }
            catch (Exception)
            {
                r.Failures++;
            }
        }

        private static bool IsLogFile(string strName)
        {
            string strExt = Path.GetExtension(strName);
            foreach (string e in LogExtensions)
            {
                if (string.Equals(e, strExt, StringComparison.OrdinalIgnoreCase)) return true;
            }
            return false;
        }
    }
}
