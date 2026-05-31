using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class Lesson27 : MonoBehaviour
{

    void Start()
    {
        #region 知识点一 上传文件到HTTP资源服务器需要遵守的规则
        //1.Content-Type必须设置为multipart/form-data
        //ContentType="multipart/form-data; boundary=自定义字符串";
        //2.上传的数据必须按照格式写入流中
        //--边界字符串
        //Content-disposition: form-data; name="参数名"; filename="文件名"
        //Content-Type:application/octet-stream (由于我们传二进制文件，所以这里使用2进制)

        //这里直接些传入的内容
        //--边界字符串--

        //3.保证服务器允许上传
        //4.写入流前需要先设置Contentlength的值    


        #endregion

        #region 知识点二 上传文件
        HttpWebRequest req = HttpWebRequest.Create("http://192.168.0.126:8000/HTTPServer/") as HttpWebRequest;
        req.Method = WebRequestMethods.Http.Post;
        req.ContentType = "multipart/form-data; boundary=MrLei";
        req.Timeout = 1000 * 50;
        req.Credentials=new NetworkCredential("admin","123456");
        req.PreAuthenticate = true;//先验证身份  再上传数据

        //按照格式拼接字符串 并且转为字节数组 之后用于上传   开始头部
        string head = "--MrLei\r\n" +
                     "Content-disposition: form-data; name=\"file\"; filename=\"http上传的文件.jpeg\"\r\n" +
                        "Content-Type:application/octet-stream\r\n\r\n";

        byte[] headBytes = System.Text.Encoding.UTF8.GetBytes(head);

        //结束边界
        byte[] endBytes = System.Text.Encoding.UTF8.GetBytes("\r\n--MrLei--\r\n");
        //需要上传的内容A
        //4.1设置上传长度  
        //4.2先写入头部信息
        //4.3再写入文件内容
        //4.4最后写入结束边界
        using (FileStream localFileStream = File.OpenRead(Application.streamingAssetsPath + "/test.jpg"))
        {

            req.ContentLength = headBytes.Length + localFileStream.Length + endBytes.Length;
            //用于上传的流
            Stream uploadStream = req.GetRequestStream();
            //写入头部信息
            uploadStream.Write(headBytes, 0, headBytes.Length);
            //写入文件内容
            byte[] buffer = new byte[2048];
            int contentLength = localFileStream.Read(buffer, 0, buffer.Length);
            while (contentLength > 0)
            {
                uploadStream.Write(buffer, 0, contentLength);
                contentLength = localFileStream.Read(buffer, 0, buffer.Length);
            }
            //写入结束边界
            uploadStream.Write(endBytes, 0, endBytes.Length);

            uploadStream.Close();
            localFileStream.Close();

        }
        //5.上传数据  获取响应
        HttpWebResponse response = req.GetResponse() as HttpWebResponse;
        if(response.StatusCode == HttpStatusCode.OK)
        {
            Debug.Log("上传成功");
        }
        else
        {
            Debug.Log("上传失败");
            Debug.Log(response.StatusCode); 
        }




    }

        #endregion
}
