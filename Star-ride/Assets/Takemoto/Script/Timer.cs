using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;
    public Text timerText;
    private int second;

     // 時間
    private ReadyTimer m_readyTimer = null;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 60;

        // Scriptを取得
        m_readyTimer = GameObject.Find("UIEvent").GetComponent<ReadyTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 4秒経過したら
        if (m_readyTimer.Ready() == true)
        {
            // ゲームが始まってすぐに1秒ごとに１ずつ減らす
            timer -= Time.deltaTime;

            // 0秒以下は0に戻す
            if (timer <= 0.0f)
            {
                timer = 0.0f;
            }

            second = (int)timer;
            // 文字を表示する
            timerText.text = second.ToString();
        }
    }
}
