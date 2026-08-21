using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace MMI
{
    public class UDP_Server
    {
        Socket Server;
        EndPoint ep;
        IPAddress ip;

        private byte[] RecvData = new byte[10000];
        private const int RecvSize = 10000;

        CThreadMMILog MMILog;
        public UDP_Server()
        {
            MMILog = CThreadMMILog.GetInstance;
            Debug.Assert(MMILog != null);
        }

        public string StartAsServer(string s_ip, string s_port)
        {
            string result = "";
            try
            {
                ip = IPAddress.Parse(s_ip);
                ep = new IPEndPoint(IPAddress.Any, Convert.ToInt32(s_port));
                Server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                Server.Bind(ep);
                Server.BeginReceiveFrom(RecvData, 0, RecvSize, SocketFlags.None, ref ep, new AsyncCallback(recvCallBack), Server);
                Trace.WriteLine("[UDP 서버 오픈]");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[UDP 서버 연결 오류] " + ex.Message);
                result = "[UDP 서버 연결 오류] " + ex.Message;
                if (Server != null)
                    Server.Close();
            }
            return result;
        }

        public void SendData(byte[] msg)
        {
            try
            {
                Server.SendTo(msg, ep);
                Trace.WriteLine("[UDP send]");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[UDP 서버 송신 오류] " + ex.Message);
            }
        }

        private void recvCallBack(IAsyncResult iar) // 시리얼 통신의 리시브 이벤트 같은것, 즉 수신되는 패킷이 없으면 발생하지 않는다.
        {
            try
            {
                Socket server = (Socket)iar.AsyncState;
                int i_recv = server.EndReceiveFrom(iar, ref ep);
                if (i_recv > 0)
                {
                    Server.BeginReceiveFrom(RecvData, 0, RecvSize, SocketFlags.None, ref ep, new AsyncCallback(recvCallBack), server);
                    string recvData = Encoding.UTF8.GetString(RecvData, 0, i_recv);
                    MMILog.AddSEQLog(recvData);
                    //Console.WriteLine($"{recvData}");
                    //Trace.WriteLine("[수신]");

                    //CheckRecvMsg(RecvData, i_recv);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[UDP 서버 수신 오류] " + ex.Message);
                if (Server != null)
                    Server.Close();
            }
        }

        private void CheckRecvMsg(byte[] recvByte, int i_recv)
        {
            byte[] tempRecv = RecvData.Take(i_recv).ToArray(); // 전체 바이트에서 실제로 수신된 바이트만 따로 골라낸다  
        }
    }
}
