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
    class UDP_Client
    {
        Socket Client;
        IPEndPoint ep;
        IPAddress ip;

        private byte[] RecvData = new byte[10000];
        private int RecvSize = 10000;

        public UDP_Client()
        {

        }

        public string StartAsClient(string s_ip, string s_port)
        {
            string result = "";
            try
            {
                ip = IPAddress.Parse(s_ip);
                ep = new IPEndPoint(ip, Convert.ToInt32(s_port));
                Client = new Socket(ep.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
                Client.BeginConnect(ep, new AsyncCallback(connectCallback), Client);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[UDP Client 연결 오류] " + ex.Message);
                result = "[UDP Client 연결 오류] " + ex.Message;
                if (Client != null)
                    Client.Close();
            }
            return result;
        }

        private void connectCallback(IAsyncResult ar)
        {
            Client = (Socket)ar.AsyncState;

            try
            {
                Client.EndConnect(ar);
                Trace.WriteLine(Client.RemoteEndPoint.ToString() + "에 연결 완료");
                Client.BeginReceive(RecvData, 0, RecvSize, SocketFlags.None, new AsyncCallback(receiveCollback), Client);
            }
            catch (SocketException ex)
            {
                Trace.WriteLine("[UDP 연결 실패] " + ex.Message);
            }
        }

        private void receiveCollback(IAsyncResult iar)
        {
            try
            {
                Socket remote = (Socket)iar.AsyncState;
                int recvSize = remote.EndReceive(iar);
                Trace.WriteLine("[recv size] " + recvSize);
                if (recvSize > 0)
                {
                    string stringData = Encoding.UTF8.GetString(RecvData, 0, recvSize);

                    CheckRecvMsg(RecvData, recvSize);
                    remote.BeginReceive(RecvData, 0, RecvSize, SocketFlags.None, new AsyncCallback(receiveCollback), remote);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[UDP Client 수신 오류] " + ex.Message);
                if (Client != null)
                    Client.Close();
            }
        }

        public void CheckRecvMsg(byte[] RecvData, int i_recvSize)
        {
            byte[] tempRecv = RecvData.Take(i_recvSize).ToArray();
        }

        public void SendData(byte[] sendByte)
        {
            try
            {
                Client.BeginSend(sendByte, 0, sendByte.Length, SocketFlags.None, new AsyncCallback(sendCallback), Client);
                Trace.WriteLine("[send]");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[UDP Client 송신 오류] " + ex.Message);
                if (Client != null)
                    Client.Close();
            }
        }

        private void sendCallback(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            int sent = remote.EndSend(iar);
        }
    }
}
