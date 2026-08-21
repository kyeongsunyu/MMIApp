using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace MMI
{
    public class SerialComm
    {
        public delegate void DataReceivedHandlerFunc(byte[] receiveData);
        public DataReceivedHandlerFunc DataReceivedHandler;

        public delegate void DisconnectedHandlerFunc();
        public DisconnectedHandlerFunc DisconnectedHandler;

        public SerialPort serialPort;

        public bool IsOpen
        {
            get
            {
                if (serialPort != null) return serialPort.IsOpen;
                return false;
            }
        }

        // serial port check
        private Thread threadCheckSerialOpen;
        private bool isThreadCheckSerialOpen = false;

        public SerialComm()
        {
        }

        public bool OpenComm(string portName, 
            int baudrate = 9600, int databits = 8 , StopBits stopbits = StopBits.One , 
            Parity parity = Parity.None, Handshake handshake = Handshake.None)
        {
            try
            {
                serialPort = new SerialPort();

                serialPort.PortName = portName;
                serialPort.BaudRate = baudrate;
                serialPort.DataBits = databits;
                serialPort.StopBits = stopbits;
                serialPort.Parity = parity;
                serialPort.Handshake = handshake;

                serialPort.Encoding = new System.Text.ASCIIEncoding();
                serialPort.NewLine = "\r\n";
                //serialPort.ErrorReceived += serialPort_ErrorReceived;
                //serialPort.DataReceived += serialPort_DataReceived;

                serialPort.Open();

                StartCheckSerialOpenThread();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        public void CloseComm()
        {
            try
            {
                if (serialPort != null)
                {
                    StopCheckSerialOpenThread();
                    serialPort.Close();
                    serialPort = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public bool Send(string sendData)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Write(sendData);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return false;
        }

        public bool Send(byte[] sendData)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Write(sendData, 0, sendData.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return false;
        }

        public bool Send(byte[] sendData, int offset, int count)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Write(sendData, offset, count);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return false;
        }

        public byte[] ReadSerialByteData()
        {
            serialPort.ReadTimeout = 100;
            byte[] bytesBuffer = new byte[serialPort.BytesToRead];
            int bufferOffset = 0;
            int bytesToRead = serialPort.BytesToRead;

            while (bytesToRead > 0)
            {
                try
                {
                    int readBytes = serialPort.Read(bytesBuffer, bufferOffset, bytesToRead - bufferOffset);
                    bytesToRead -= readBytes;
                    bufferOffset += readBytes;
                }
                catch (TimeoutException ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return bytesBuffer;
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string strBuffer = serialPort.ReadLine();

                //byte[] bytesBuffer = ReadSerialByteData();
                //string strBuffer = Encoding.ASCII.GetString(bytesBuffer);

                //if (DataReceivedHandler != null)
                //    DataReceivedHandler(bytesBuffer);

                Debug.WriteLine("received(" + strBuffer.Length + ") : " + strBuffer);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Debug.WriteLine(e.ToString());
        }

        private void StartCheckSerialOpenThread()
        {
            isThreadCheckSerialOpen = true;
            threadCheckSerialOpen = new Thread(new ThreadStart(ThreadCheckSerialOpen));
            threadCheckSerialOpen.Start();
        }

        private void StopCheckSerialOpenThread()
        {
            if (isThreadCheckSerialOpen)
            {
                isThreadCheckSerialOpen = false;
                if (Thread.CurrentThread != threadCheckSerialOpen)
                    threadCheckSerialOpen.Join();
            }
        }

        private void ThreadCheckSerialOpen()
        {
            while (isThreadCheckSerialOpen)
            {
                Thread.Sleep(100);

                try
                {
                    if (serialPort == null || !serialPort.IsOpen)
                    {
                        Debug.WriteLine("seriaport disconnected");
                        if (DisconnectedHandler != null)
                            DisconnectedHandler();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
        }
    }


    //< SerialComm 사용 >

    //using System.IO.Ports;

    //...
    //SerialComm serial = new SerialComm();
    //serial.DataReceivedHandler = DataReceivedHandler;
    //serial.DisconnectedHandler = DisconnectedHandler;
    //...
    //serial.OpenComm("COM3", 9600, 8, StopBits.One, Parity.None, Handshake.None);
    //...
    //serial.CloseComm();

    //private void DataReceivedHandler(byte[] receiveData)
    //{
    //    // do something with receiveData here
    //}

    //private void DisconnectedHandler()
    //{
    //    Console.WriteLine("serial disconnected");
    //}


}
