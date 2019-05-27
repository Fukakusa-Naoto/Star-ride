using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;
    public Text timerText;
    private int second;
    private int cntTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // 4秒待つ
        if (cntTimer < 240) 
        {
            cntTimer++;
        }

        // 4秒経過したら
        if (cntTimer >= 240)
        {
            // ゲームが始まってすぐに1秒ごとに１ずつ減らす
            timer -= Time.deltaTime;

            second = (int)timer;
            // 文字を表示する
            timerText.text = second.ToString();
        }
    }
}
