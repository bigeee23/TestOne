using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollView : MonoBehaviour
{
   
    void Start()
    {
        ScrollRect sr = this.GetComponent<ScrollRect>();
        //控制content内容大小的尺寸
        //sr.content.sizeDelta=new Vector2(500,500); 
        //控制content内容的位置，（0,0）表示左下角
        sr.normalizedPosition = new Vector2(0, 1f);
        
        //获取content内容滑动条的位置，打印参数为Vector2类型的  （0,0）左下角
        sr.onValueChanged.AddListener((vec) =>
        {
            //print(vec);
        });
    }

    
    void Update()
    {
        Add();
    }

    void Add()
    {

        //修改测试代码
    }
}
