//__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/
//! @file		ReadyTimer.cs
//!
//! @summary	スタートに関するC#スクリプト
//!
//! @date		2019.05.28
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
    // Timeupの画像情報
    private Image m_timeup;

    // カウント
    public static int m_cnt = 0;

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
        m_timeup = GameObject.Find("UI_Sentens/Timeup").GetComponent<Image>();

        // 初期化
        m_cnt = 0;

        // 最初は非表示
        m_go.enabled = false;
        m_timeup.enabled = false;

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

        if (m_cnt >= 60 * 2)              // 2秒後に消して表示
        {
            m_ready.enabled = false;
            m_go.enabled = true;
        }
        
        if (m_cnt >= 60 * 4)               // 4秒後に消す
        {
            m_go.enabled = false;
        }

        if (m_cnt > 60 * (4 + 59))         // 終了後2秒間表示
        {
            m_timeup.enabled = true;
        }

        if (m_cnt >= 60 * (4 + 59 + 2))    // 2秒後に消す
        {
            m_timeup.enabled = false;
        }
    }

    //--------------------------------------------------------------------
    //! @summary   開始終了の判別処理
    //!
    //! @parameter [bool] なし
    //!
    //! @return    true/false
    //--------------------------------------------------------------------
    public bool Ready()
    {
        // 開始（4秒後かつ、60秒経過後）
        if ((m_cnt >= 60 * 4) && (m_cnt < 60 * (4 + 59)))
        {
            return true;
        }

        // 終了
        return false;
    } 
}
