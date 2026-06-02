using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Lesson30 : MonoBehaviour
{
    public RawImage image;
    void Start()
    {
        #region  UnityWebRequest类的常用操作
        //1.使用Get请求获取文本或二进制数据
        //2.使用Get请求获取文理数据  图片数据
        //3.使用Get请求获取AB包数据
        //4.使用Post请求发送数据

        #endregion

        #region  Get获取操作
        //1.获取文本或二进制数据
        //2.获取文理数据
        //3.获取AB包数据
        #endregion
    }


    IEnumerator LoadText()
    {
        //1.创建UnityWebRequest对象
        UnityWebRequest req = UnityWebRequest.Get("http://www.example.com/data.txt");
        //2.发送请求并等待服务器响应
        yield return req.SendWebRequest();
        //3.获取服务器响应的数据
        if (req.result == UnityWebRequest.Result.Success)
        {
            string textData = req.downloadHandler.text;
            Debug.Log("获取到的文本数据: " + textData);

            //字节数组
            byte[] bytes=req.downloadHandler.data;
             Debug.Log("获取到的字节数据长度: " + bytes.Length);
        }
        else
        {
            Debug.LogError("请求失败: " + req.error);
        }
        //4.处理数据

        yield return null;
    }

    IEnumerator LoadTexture()
    {
        UnityWebRequest req = UnityWebRequestTexture.GetTexture("http://www.example.com/image.png");
        yield return req.SendWebRequest();
        if (req.result == UnityWebRequest.Result.Success)
        {
            //image.texture = (req.downloadHandler as DownloadHandlerTexture).texture;
            Texture2D texture = DownloadHandlerTexture.GetContent(req);
            Debug.Log("获取到的纹理数据: " + texture);
        }
        else
        {
            Debug.LogError("请求失败: " + req.error);
        }
        yield return null;
    }

    IEnumerator LoadAssetBundle()
    {
        UnityWebRequest req = UnityWebRequestAssetBundle.GetAssetBundle("http://www.example.com/assetbundle");
        yield return req.SendWebRequest();
        while(!req.isDone)
        {
            Debug.Log("下载进度: " + req.downloadProgress);
            Debug.Log("下载完成: " + req.downloadedBytes + "字节");
            yield return null;
        }


        if (req.result == UnityWebRequest.Result.Success)
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(req);
            Debug.Log("获取到的AB包数据: " + bundle);
        }
        else
        {
            Debug.LogError("请求失败: " + req.error);
        }
        yield return null;
    }
   
    void Update()
    {
        
    }
}
