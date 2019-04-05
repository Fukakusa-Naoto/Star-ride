using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour
{
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // 時間経過でシーン移動
        if (Time.time - startTime > 60f)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
