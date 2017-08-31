using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System;
using System.Collections.Generic;

namespace TCPNet
{
    public class SocketClient
    {
        byte[] Buffer = new byte[4096];
        List<byte> receiveBuffer = new List<byte>(4096);
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Action<bool> onConnect;
        public Action<bool, byte[]> onReceive;

        int failCon = 0;
        int failCout = 3;

        public SocketClient()
        {
        }
        IPEndPoint endpoint;
        public void connect(string _ip, int _port)
        {
            IPAddress address = IPAddress.Parse(_ip);
            endpoint = new IPEndPoint(address, _port);
            socket.BeginConnect(endpoint, new System.AsyncCallback(connectCallback), socket);
        }

        void connectCallback(System.IAsyncResult ar)
        {
            if (socket.Connected)
            {
                if (onConnect != null)
                {
                    onConnect(true);
                }
                //开始异步等待接收服务端消息           
                socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new System.AsyncCallback(ReceiveFromServer), socket);
            }
            else
            {
                if (failCon == failCout)
                {
                    if (onConnect != null)
                    {
                        onConnect(false);
                    }
                }
                else
                {
                    failCon++;

                    Debug.Log("connect fail ,start again:" + failCon);
                    socket.BeginConnect(endpoint, new System.AsyncCallback(connectCallback), socket);
                }
            }
        }

        void ReceiveFromServer(System.IAsyncResult ar)
        {
            if (socket == null || !socket.Connected)
                return;


            int ByteRead = 0;
            try
            {
                //接收完毕消息后的字节数
                ByteRead = socket.EndReceive(ar);
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex.Message);
                if (onReceive != null)
                {
                    onReceive(false, ex.ToString().ToBytes());
                }
            }

            if (ByteRead > 0)
            {
                byte[] buf = new byte[ByteRead];
                System.Buffer.BlockCopy(Buffer, 0, buf, 0, ByteRead);
                receiveBuffer.AddRange(buf);

                while (receiveBuffer.Count > 4)
                {
                    byte[] lenBytes = receiveBuffer.GetRange(0, 4).ToArray();
                    int len = IPAddress.HostToNetworkOrder(BitConverter.ToInt32(lenBytes, 0));
                    // one protocol data received  
                    if (receiveBuffer.Count - 4 >= len)
                    {
                        byte[] dataBytes = receiveBuffer.GetRange(4, len).ToArray();

                        if (onReceive != null)
                        {
                            onReceive(true, dataBytes);
                        }
                        receiveBuffer.RemoveRange(0, len + 4);
                    }
                    else
                    {
                        break;
                        // protocol data not complete   
                    }
                }
            }

            //继续异步等待接受服务器的返回消息
            socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new System.AsyncCallback(ReceiveFromServer), socket);
        }

        public void send(byte[] data)
        {
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new System.AsyncCallback(SendCallback), socket);
        }

        private void SendCallback(System.IAsyncResult asyncConnect)
        {
            if (asyncConnect.IsCompleted)
            {
                Debug.Log("send success");
            }
            else
            {
                Debug.Log("send fail");
            }

            int bytesend = socket.EndSend(asyncConnect);
        }

        public void close()
        {
            if (socket == null) return;
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            socket = null;
        }

        public bool connected
        {
            get
            {
                return socket.Connected;
            }
        }
    }

}

