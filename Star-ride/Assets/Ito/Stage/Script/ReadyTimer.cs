//__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/
//! @file		ReadyTimer.cs
//!
//! @summary	スタートに関するC#スクリプト
//!
//! @date		2019.05.24
//!
//! @author		伊藤瑠花
//__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/

// 名前空間の省略 ===========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// クラスの定義 =============================================================
public class ReadyTimer : MonoBehaviour
{

    // <メンバ変数>
    // Readyの画像情報
    private Image m_ready;
    // Goの画像情報
    private Image m_go;

    // カウント
    private int m_cnt = 0;

    // メンバ関数の定義 =====================================================
    //--------------------------------------------------------------------
    //! @summary   初期化処理
    //!
    //! @parameter [void] なし
    //!
    //! @return    なし
    //--------------------------------------------------------------------
    void Start()
    {
        // 画像の取得
        m_ready = GameObject.Find("UI_Sentens/Ready").GetComponent<Image>();
        m_go = GameObject.Find("UI_Sentens/Go").GetComponent<Image>();

        // 最初は非表示
        m_go.enabled = false;
    }

    //--------------------------------------------------------------------
    //! @summary   更新処理
    //!
    //! @parameter [void] なし
    //!
    //! @return    なし
    //--------------------------------------------------------------------
    void Update()
    {
        // 時間の加算
        m_cnt++;
        //Debug.Log(m_cnt);

        if (m_cnt >= 240)              // 4秒後に消す
        {
            m_go.enabled = false;
        }
        else if (m_cnt >= 120)         // 2秒後に消して表示
        {
            m_ready.enabled = false;
            m_go.enabled = true;
        }
    }
}
