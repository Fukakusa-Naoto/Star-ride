using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   public float timer;
   public Text timerText;
    int second;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
            // 1秒ごとに１ずつ減らす
            timer -= Time.deltaTime;
        

        second = (int)timer;
        timerText.text = second.ToString();
        
    }
}
