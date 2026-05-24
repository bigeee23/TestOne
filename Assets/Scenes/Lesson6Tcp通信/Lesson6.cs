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
        #region ֪ʶ��һ �ع˿ͻ�����Ҫ������
        //1.�����׽���Socket
        //2.��Connect���������˽�������
        //3.��Send��Receive��ط����շ���Ϣ
        //4.��ShutDown�����ͷ�����
        //5.�ر��׽���Socket
        #endregion


        #region ֪ʶ��� ʵ�ֿͻ��˻����߼�
        //1.�����׽���Socket
        Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

        //2.��Connect���������˽�������
        //ȷ�������IP�Ͷ˿�
        IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
        try
        {
            socket.Connect(ip);
        }
        catch (SocketException e)
        {
            if(e.ErrorCode == 10061)
            {
                print("�������ܾ�����");
            }
            else
            {
                print("����������ʧ��" + e.ErrorCode);
            }

            return;

        }

        //3.��Send��Receive��ط����շ���Ϣ
        //��������
        byte[] Rbytes = new byte[1024];

        int receiveNum = socket.Receive(Rbytes);

        print("�յ���������Ϣ:"+Encoding.UTF8.GetString(Rbytes,0,receiveNum));

        //������Ϣ
   
        socket.Send(Encoding.UTF8.GetBytes("��ã����ǿͻ�����ά"));

        //4.��ShutDown�����ͷ�����
        socket.Shutdown(SocketShutdown.Both);

        //5.�ر��׽���Socket
        socket.Close();

        #endregion
    }


    void Update()
    {
        
    }
}
