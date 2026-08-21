using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace MMI
{
    public class CTcpClientAsync : CTcpBase
    {
        // ManualResetEvent instances signal completion.
        private ManualResetEvent connectDone = new ManualResetEvent(false);
        private ManualResetEvent sendDone = new ManualResetEvent(false);
        private ManualResetEvent receiveDone = new ManualResetEvent(false);

        // The response from the remote device.
        private String response = String.Empty;

        public delegate void DeleConnected(bool bConnected, string msg = "");
        public event DeleConnected deleConnected = null;

        public delegate void DeleDisconnected(string msg = "");
        public event DeleDisconnected deleDisconnected = null;

        public delegate void DeleReceived(Socket sw, string msg);
        public event DeleReceived deleReceived = null;

        public delegate void DeleSent(Socket sw, int sentLen);
        public event DeleSent deleSent = null;

        public CTcpClientAsync()
        {
        }

        public CTcpClientAsync(IPAddress ipAddr, int port)
        {
            SetClientInfo(ipAddr, port);
        }

        public bool SetClientInfo(IPAddress ipAddr, int port)
        {
            socketInfo.ipAddr = ipAddr;
            socketInfo.port = port;

            return true;
        }

        public bool SetClientInfo(string ipAddr, int port)
        {
            if (IPAddress.TryParse(ipAddr, out socketInfo.ipAddr) == false)
                return false;

            socketInfo.port = port;

            return true;
        }

        public void Connect(bool wait = false)
        {
            // Connect to a remote device.
            try
            {
                IPEndPoint remoteEP = new IPEndPoint(socketInfo.ipAddr, socketInfo.port);

                // Create a TCP/IP socket.
                SOCKET = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.
                SOCKET.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), stateObject.socket);

                if (wait) connectDone.WaitOne();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// 서버와 연결되었을 때 호출되는 callback 함수입니다.
        /// </summary>
        /// <param name="ar">비동기 작업 상태</param>
        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.
                connectDone.Set();

                if (deleConnected != null)
                    deleConnected(true);

                Receive(client);
            }
            catch (System.Net.Sockets.SocketException e)
            {
                Console.WriteLine(e.ToString());

                // 대상 컴퓨터에서 연결을 거부했으므로 연결하지 못했습니다
                if (e.ErrorCode == 10061)
                {
                    if (deleConnected != null)
                        deleConnected(false, e.Message);
                }
                else
                {
                    if (deleConnected != null)
                        deleConnected(false, e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                if (deleConnected != null)
                    deleConnected(false, e.Message);
            }
        }

        /// <summary>
        /// 소켓에 메시지를 받도록 비동기로 대기합니다.
        /// 연결 후 항상 수신 상태로 있습니다.
        /// 1byte씩 받고 delimeter가 empty일 경우 지속적으로 deleReceived를 호출합니다.
        ///              delimeter가 empty가 아닐 경우 그 문자열이 들어오면 deleReceived를 호출합니다.
        /// </summary>
        /// <param name="socket">서버와 연결된 소켓입니다</param>
        private void Receive(Socket socket)
        {
            try
            {
                // Create the state object.
                StateObject state = new StateObject();
                state.socket = socket;

                // Begin receiving the data from the remote device.
                SOCKET.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (System.Net.Sockets.SocketException e)
            {
                Console.WriteLine(e.ToString());

                // Error Code 10054 : Client 연결 끊김
                if (e.ErrorCode == 10054)
                {
                    if (deleDisconnected != null)
                        deleDisconnected(e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// 소켓에 메시지를 받은 후 들어오는 callback 함수
        /// </summary>
        /// <param name="ar">비동기 작업 상태</param>
        private void ReceiveCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.socket;

                // Read data from the remote device.
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    content = state.sb.ToString();
                    if (delimiterEndMsg == string.Empty || content.IndexOf(delimiterEndMsg) > -1)
                    {
                        if (deleReceived != null)
                            deleReceived(client, content);

                        state.sb.Clear();
                    }

                    // Get the rest of the data.
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
            }
            catch (System.Net.Sockets.SocketException e)
            {
                Console.WriteLine(e.ToString());

                // Error Code 10054 : Client 연결 끊김
                if (e.ErrorCode == 10054)
                {
                    if (deleDisconnected != null)
                        deleDisconnected(e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// 소켓에 Data를 Send한다
        /// </summary>
        /// <param name="data">보낼 String 데이터</param>
        public void Send(String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            Send(byteData);
        }

        /// <summary>
        /// 소켓에 Data를 Send한다
        /// </summary>
        /// <param name="byteData">보낼 byte 배열 데이터</param>
        public void Send(byte[] byteData)
        {
            try
            {
                // Begin sending the data to the remote device.
                SOCKET.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), SOCKET);
            }
            catch (System.Net.Sockets.SocketException e)
            {
                Console.WriteLine(e.ToString());

                // Error Code 10053 : "현재 연결은 사용자의 호스트 시스템의 소프트웨어의 의해 중단되었습니다"
                if (e.ErrorCode == 10053)
                {
                    if (deleDisconnected != null)
                        deleDisconnected(e.Message);
                }

                // Error Code 10054 : Client 연결 끊김
                if (e.ErrorCode == 10054)
                {
                    if (deleDisconnected != null)
                        deleDisconnected(e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// 소켓을 Send한 후 들어오는 callback 함수
        /// </summary>
        /// <param name="ar">비동기 작업 상태</param>
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                if (deleSent != null)
                    deleSent(client, bytesSent);

                // Signal that all bytes have been sent.
                sendDone.Set();
            }
            catch (System.Net.Sockets.SocketException e)
            {
                Console.WriteLine(e.ToString());

                // Error Code 10054 : Client 연결 끊김
                if (e.ErrorCode == 10054)
                {
                    if (deleDisconnected != null)
                        deleDisconnected(e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
