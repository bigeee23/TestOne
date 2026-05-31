using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mime;
using UnityEngine;

public class Lesson26 : MonoBehaviour
{
    
    void Start()
    {
        #region Get和Post
        //Get  一般用于获取数据，参数会暴露在URL中，主要用于数据获取  暴露式的
        //Post  一般用于提交数据，参数会包含在请求体中，安全性较高，适合敏感数据的传输 隐藏式的
        #endregion



        #region Post如何携带额外参数 
        //关键点： 将Content-Type设置为application/x-www-from-urlencoded 键值对类型

        HttpWebRequest req= HttpWebRequest.Create("http://192.168.0.126:8000/HTTPServer/") as HttpWebRequest;
        req.Method = WebRequestMethods.Http.Post;   
        req.Timeout=3000;
        //设置上传的内容的类型
        req.ContentType = "application/x-www-form-urlencoded";
        //我们要上传的数据
        string str="Name=MrLei&ID=24";
        //将字符串转换为字节数组
        byte [] bytes=System.Text.Encoding.UTF8.GetBytes(str);
        //设置上传内容的长度
        req.ContentLength=bytes.Length;
        //获取请求流
        Stream reqStream=req.GetRequestStream();
        //将数据写入请求流
        reqStream.Write(bytes,0,bytes.Length);
        reqStream.Close();
        //发送数据 得到响应结果
        HttpWebResponse res=req.GetResponse() as HttpWebResponse;
        Debug.Log("响应状态码:"+res.StatusCode);



        #endregion


        #region ContentType 的常用类型

        //ContentType 的构成
        //内容类型 charset=编码格式; boundary=边界字符串; name=参数名; filename=文件名
        //text/html; charset=UTF-8; boundary=自定义字符串 
        req.ContentType="变化的;charset=变化的;bounday=变化的";
        req.ContentType="application/x-www-form-urlencode;charset=utf-8;bounday=Mrlei";
        //内容类型有
        //文本类型text
        //text/plain 纯文本 没有特定子类型就是它（重要）
        //text/html HTML文本
        //text/css CSS文本
        //text/javascript JavaScript文本

        //图片类型image
        //image/jpeg JPEG图片
        //image/png PNG图片
        //image/gif GIF图片

        //音频类型audio
        //audio/mpeg MP3音频
        //audio/wav WAV音频
        //audio/ogg OGG音频
        //audio/flac FLAC音频

        //视频类型video
        //video/mp4 MP4视频
        //vidop/ogg OGG视频

        //二进制类型 application
        //application/octet-stream 二进制流（默认） 没有特定子类型就是它（重要）
        //application/x-www-form-urlencoded 键值对类型  Post携带参数时常用的类型 (重要)
        //application/json JSON格式数据
        //application/xml XML格式数据
        //application/pdf PDF文档

        //复合类型 multipart
        //multipart/form-data 表单数据 主要用于文件上传  复合内容 有多种内容组合（重要）
        //multipart/byteranges 字节范围 主要用于断点续传  特殊的复合文件

        #endregion


        #region  ContentType 中对于我们来说的重要的类型
        //通用二进制类型
        //application/octet-stream 二进制流（默认） 没有特定子类型就是它（重要）
        //通用文本类型
        //text/plain 纯文本 没有特定子类型就是它（重要）
        //键值对类型
        //application/x-www-form-urlencoded 键值对类型  Post携带参数时常用的类型 (重要)
        //复合内容类型
        //multipart/form-data 表单数据 主要用于文件上传  复合内容 有多种内容组合（重要）
        #endregion
    }

  
    void Update()
    {
        
    }
}
