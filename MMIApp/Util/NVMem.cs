using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Windows.Forms;

namespace MMI
{
    //-- NV 메모리 개념은 MemoryMappedFile을 사용하여 파일을 생성하고, 생성된 파일을 동일한 파일명으로 다른 프로세스에서도 참조 가능하다.
    //-- 현재는 단독으로 쓰고 있으므로 Create를 사용한다. 
    //-- 구글신 도움으로 https://icodebroker.tistory.com/12259 에서 참조를 했다.
    //-- 이전에는 바이트 어레이를 스트럭처로, 스트럭처를 바이트 어레이로 쫌 지지분하게 썼었다. 
    public class NVMem
    {
        public static int SIZE = 0x4000;
        public static MemoryMappedFile mmf;
        public static MemoryMappedViewAccessor accessor;
        public static string sNvMapFileName = "";

        // NV 초기화...
        public bool Init(string sName = "NVMemory")
        {
            var path = "";
            sNvMapFileName = sName;

            path = $@"{Environment.CurrentDirectory}\{sNvMapFileName}.dat";
            try
            {
                mmf = MemoryMappedFile.CreateFromFile(path, FileMode.OpenOrCreate, sNvMapFileName, SIZE,
                    MemoryMappedFileAccess.ReadWrite);
                accessor = mmf.CreateViewAccessor(0, SIZE, MemoryMappedFileAccess.ReadWrite);
            }
            catch (Exception ex)
            {
                MessageBox.Show(sNvMapFileName + ex + "Failed to init NV!!!");
                return false;
            }

            return true;
        }

        //-- accessor의 nNo번째에 있는 값을 nVal로 변경 한다
        //-- 개별 Read/Write를 이용할 필요가 있을까? Struct(class)의 일부 값을 변경하고 한번에 저장 하는것을 추천.
        public void Write(int nNo, int nVal)
        {
            var nOffset = nNo * sizeof(int);
            try
            {
                if (accessor.CanWrite)
                {
                    accessor.Write(nOffset, nVal);
                    accessor.Flush();
                }
            }
            catch (Exception e)
            {
                //CSEQ.AddLog($"MMF Write Exception : {e.Message}");
                e.Message.ToString();
            }
        }


        public int Read(int nNo)
        {
            var nVal = 0;
            var nOffset = nNo * sizeof(int);
            try
            {
                if (accessor.CanRead)
                    nVal = accessor.ReadInt32(nOffset);
            }
            catch (Exception e)
            {
                //CSEQ.AddLog($"MMF Read Exception : {e.Message}");
                e.Message.ToString();
            }

            return nVal;
        }

        //-- Struct(Class)의 일부값을 바꾸고 한번에 더저줘서 
        public void Write<T>(long offset, T source) where T : struct
        {
            try
            {
                if (accessor.CanWrite)
                {
                    accessor.Write(offset, ref source);
                    accessor.Flush();
                }
            }
            catch (Exception e)
            {
                //CSEQ.AddLog($"MMF Write Struct Exception : {e.Message}");
                e.Message.ToString();
            }
        }

        public T Read<T>(long offset = 0) where T : struct
        {
            T target;
            accessor.Read(offset, out target); //-- try catch를 못 건다, 주의해서 사용하자.ㅠㅠ
            return target;
        }
    }
}
