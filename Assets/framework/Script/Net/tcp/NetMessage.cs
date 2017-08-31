using UnityEngine;
using System.Collections;
using System;

namespace TCPNet
{
    public class NetMessage
    {
        public NetMessage(byte[] data)
        {
            NetStream ns = new NetStream();
            ns.WriteInt32(data.Length);
            byte[] header = ns.GetBuffer();

            context = new byte[header.Length + data.Length];//算出数据加包头的总大小  
            Array.Copy(header, 0, context, 0, header.Length);//先把包头存进去  
            Array.Copy(data, 0, context, header.Length, data.Length);//再把数据存进去，起始位置要设成包头的后面噢  
        }
        
        public byte[] context { get; private set; }
    }
}




