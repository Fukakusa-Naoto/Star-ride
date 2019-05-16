using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.UI.Text>().text = "00";
        
        // 初期値を60秒に設定
        timer = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // 1秒ごとに１ずつ減らす
        timer -= Time.deltaTime;

       // GetComponent<UnityEngine.UI.Text>().text = ((float)timer).ToString();

        // マイナス表示しない
        if(timer < 0)
        {
            timer = 0;
            GetComponent<Text>().text = ((float)timer).ToString();
        }
    }
}
