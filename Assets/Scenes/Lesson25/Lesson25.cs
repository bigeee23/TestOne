using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using Unity.IO.LowLevel.Unsafe;
using System.IO;

public class Lesson25 : MonoBehaviour
{
   
    void Start()
    {
        #region 知识点一检测资源可用性

        try
        {
             HttpWebRequest req=HttpWebRequest.Create("http://192.168.0.126:8000/HTTPServer/%E6%89%93%E6%8B%B3.jpg") as HttpWebRequest;
        //2.设置请求类型 或 其他相关参数
        req.Method=WebRequestMethods.Http.Head;
        req.Timeout=3000;
        //3.发送请求 获取响应结果HttpWebResponse对象
        HttpWebResponse res=req.GetResponse() as HttpWebResponse;
        if (res.StatusCode == HttpStatusCode.OK)
        {
            Debug.Log("资源可用");
            Debug.Log($"资源类型{res.ContentType}");
            Debug.Log($"资源长度{res.ContentLength}");
        }
        else
        {
            Debug.Log($"资源不可用{res.StatusCode}");
        }
        }
        catch(WebException e)
        {
            Debug.Log($"请求发生异常{e.Message}+{e.Status}");
          
        }

        //利用Head请求类型 获取信息

        #endregion

        #region 知识点二 资源下载
        //利用Get请求类型 下载资源
        try
        {
            HttpWebRequest req=HttpWebRequest.Create("http://192.168.0.126:8000/HTTPServer/%E6%89%93%E6%8B%B3.jpg") as HttpWebRequest;
            //2.设置请求类型 或 其他相关参数
            req.Method=WebRequestMethods.Http.Get;
            req.Timeout=3000;
            //3.发送请求 获取响应结果HttpWebResponse对象
            HttpWebResponse res=req.GetResponse() as HttpWebResponse;
            if (res.StatusCode == HttpStatusCode.OK)
            {
                Debug.Log("资源下载成功");
                Debug.Log($"路径{Application.persistentDataPath}");
                using(FileStream filestream = File.Create(Application.persistentDataPath + "/打拳.jpg"))
                {
                    Stream downLoadStream = res.GetResponseStream();
                    byte[] bytes = new byte[2048];
                    //读取数据
                    int contentLength=downLoadStream.Read(bytes,0,bytes.Length);
                    //一点一点的写入本地
                    while(contentLength>0)
                    {
                        filestream.Write(bytes,0,contentLength);
                        contentLength=downLoadStream.Read(bytes,0,bytes.Length);
                    }
                    filestream.Close(); 
                    downLoadStream.Close(); 
                    res.Close();    
                }
               
            }
            else
            {
                Debug.Log($"资源下载失败{res.StatusCode}");
            }
        }
        catch(WebException e)
        {
            Debug.Log($"请求发生异常{e.Message}+{e.Status}");
          
        }
        #endregion
    }

    
    void Update()
    {
        
    }
}
