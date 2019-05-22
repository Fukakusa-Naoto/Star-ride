using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   public float timer;
   public Text timerText;
   int second;
    float countTimer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // ゲームが始まってすぐに1秒ごとに１ずつ減らす
            timer -= 60;

            second = (int)timer;
        // 文字を表示する
            timerText.text = second.ToString();
            
    }
}
