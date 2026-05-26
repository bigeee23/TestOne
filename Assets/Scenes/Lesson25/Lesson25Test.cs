using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson25Test : MonoBehaviour
{
   
    void Start()
    {
        HttpManager.Instance.DownLoadFile("打拳.jpg", Application.persistentDataPath, (code) =>
        {
            if (code == System.Net.HttpStatusCode.OK)
            {
                Debug.Log($"路径{Application.persistentDataPath}");
                Debug.Log("下载成功");
            }
            else
            {
                Debug.Log($"下载失败{code}");
            }
        });
    }

   
    void Update()
    {
        
    }
}
