using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Lesson6 : MonoBehaviour
{
  
    void Start()
    {
        #region 知识点一 回顾客户端需要做的事
        //1.创建套接字Socket
        //2.用Connect方法与服务端建立连接
        //3.用Send和Receive相关方法收发消息
        //4.用ShutDown方法释放连接
        //5.关闭套接字Socket
        #endregion


        #region 知识点二 实现客户端基本逻辑
        //1.创建套接字Socket
        Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

        //2.用Connect方法与服务端建立连接
        //确定服务端IP和端口
        IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
        try
        {
            socket.Connect(ip);
        }
        catch (SocketException e)
        {
            if(e.ErrorCode == 10061)
            {
                print("服务器拒绝连接");
            }
            else
            {
                print("服务器连接失败" + e.ErrorCode);
            }

            return;

        }

        //3.用Send和Receive相关方法收发消息
        //接收数据
        byte[] Rbytes = new byte[1024];

        int receiveNum = socket.Receive(Rbytes);

        print("收到服务器消息:"+Encoding.UTF8.GetString(Rbytes,0,receiveNum));

        //发送消息
   
        socket.Send(Encoding.UTF8.GetBytes("你好，我是客户端乐维"));

        //4.用ShutDown方法释放连接
        socket.Shutdown(SocketShutdown.Both);

        //5.关闭套接字Socket
        socket.Close();

        #endregion
    }


    void Update()
    {
        
    }
}
