using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class Lesson24 : MonoBehaviour
{
    
    void Start()
    {
        #region HttpWebRequest类


        //命名空间:System.Net
        //主要用于: 发送HTTP客户端请求给服务器 可以进行消息通信 下载 上传等操作
        
        //重要方法
        //1.Create 创建新的WebRequest， 用于进行HTTP相关操作
        HttpWebRequest req=HttpWebRequest.Create("http://www.google.com") as HttpWebRequest;
        
        //2.Abort  如果在进行传输时，使用此方法中断传输
        //req.Abort();
        
        //3.GetRequestStream()  用于获取上传的流
        Stream str = req.GetRequestStream();
        
        //4.GetResponse() 返回HTTP服务器响应
        HttpWebResponse res= req.GetResponse()  as HttpWebResponse;


        //重要的成员
        //1.Credentials  通信凭证 设置维NetWorkCredential对象
        //req.Credentials=new NetworkCredential("username","password");
        //2.PreAuthenticate  是否在发送请求前进行身份验证 一般需要进行身份验证时需要将其设置维true
        //req.PreAuthenticate=true;

        //3.Headers  请求头信息  可以通过它来设置一些请求头信息
        //req.Headers.Add("key","value");
        //4.Contentlength  请求内容的长度  需要在上传数据时设置
        //req.ContentLength=1024;
        //5.contentType   在进行Post请求时 请求内容的类型  需要在上传数据时设置   
        //req.ContentType="";
        //6.Method  请求方法  GET POST Head
        //WebRequestMethods.Http  类中的操作命令属性
        //Get   获取请求 ，一般用于获取数据
        //Post  提交请求  一般用于上传数据
        //Head  获取请求头信息  只是返回消息头  不会返回具体数据
        //Put   更新请求  一般用于更新数据
        #endregion

        #region  HttpWebResponse类  
        #endregion

    }

  
    void Update()
    {
        
    }
}
