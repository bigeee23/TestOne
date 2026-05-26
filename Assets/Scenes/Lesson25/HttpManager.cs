using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.Events;
using System.Net;
using System.Threading.Tasks;
using System.IO;

public class HttpManager
{

    private static HttpManager instance = new HttpManager();

    public static HttpManager Instance
    {
        get
        {
            return instance;
        }
    }

    private string Http_path = "http://192.168.0.126:8000/HTTPServer/";

    public async void DownLoadFile(string filename, string localPath, UnityAction<HttpStatusCode> action)
    {
        HttpStatusCode resultCode = HttpStatusCode.OK;
        await Task.Run(() =>
        {
            try
            {
                HttpWebRequest req = HttpWebRequest.Create(Http_path + filename) as HttpWebRequest;
                req.Method = WebRequestMethods.Http.Head;

                req.Timeout = 3000;

                HttpWebResponse res = req.GetResponse() as HttpWebResponse;

                if (res.StatusCode == HttpStatusCode.OK)
                {

                    req.Method = WebRequestMethods.Http.Get;

                    res = req.GetResponse() as HttpWebResponse;

                    if (res.StatusCode == HttpStatusCode.OK)
                    {

                        /*  using (FileStream filestream = File.Create(localPath + "/" + filename))
                         {
                             using (Stream stream = res.GetResponseStream())
                             {
                                 stream.CopyTo(filestream);
                             }
                         } */


                        using (FileStream filestream = File.Create(localPath + "/" + filename))
                        {
                            Stream strem = res.GetResponseStream();
                            byte[] byres = new byte[4096];
                            int contentLength = strem.Read(byres, 0, byres.Length);
                            while (contentLength > 0)
                            {
                                filestream.Write(byres, 0, contentLength);
                                contentLength = strem.Read(byres, 0, byres.Length);
                            }
                            filestream.Close();
                            strem.Close();
                        }
                        resultCode = HttpStatusCode.OK;

                    }
                    else
                    {
                        resultCode = res.StatusCode;
                    }

                }

                else
                {
                    resultCode = res.StatusCode;
                   
                }
                 res.Close();
            }
            catch (WebException e)
            {
                resultCode = e.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError;
                Debug.Log($"下载或者请求出错{e.Message}+{e.Status}");
            }

        });

        action?.Invoke(resultCode);

    }

}
