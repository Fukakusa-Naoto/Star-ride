using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // スクリーンサイズ
    private static int SCREEN_WIDTH = 375;
    private static int SCREEN_HEIGHT = 667;

    void Awake()
    {
        // PC向けビルドだったらサイズ変更
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
        Application.platform == RuntimePlatform.OSXPlayer ||
        Application.platform == RuntimePlatform.LinuxPlayer)
        {
            Screen.SetResolution(SCREEN_WIDTH, SCREEN_HEIGHT, false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (Screen.orientation)
        {
            // 横画面のとき
            case ScreenOrientation.LandscapeLeft:
                // 縦画面にする
                Screen.orientation = ScreenOrientation.Portrait;
                break;
            case ScreenOrientation.LandscapeRight:
                // 縦画面にする
                Screen.orientation = ScreenOrientation.Portrait;
                break;
        }
    }
}
