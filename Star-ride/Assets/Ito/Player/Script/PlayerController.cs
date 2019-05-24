//__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/
//! @file		PlayerUIController_F.cs
//!
//! @summary	プレイヤー落下に関するC#スクリプト
//!
//! @date		2019.05.24
//!
//! @author		伊藤瑠花
//__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/

// 名前空間の省略 ===========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// クラスの定義 =============================================================
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_rigidbody = null;
    private PlayerUIController m_UIController = null;
    private UnitController m_UnitController = null;

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
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_UIController = GameObject.Find("ControllerUI").GetComponent<PlayerUIController>();
        m_UnitController = GetComponent<UnitController>();
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
        // 落下フラグが立っていたら更新しない
        if (m_UnitController.IsFall()) return;

        m_rigidbody.AddForce(m_UIController.GetSendForce(), ForceMode2D.Impulse);

        // 減速処理
        if (m_rigidbody.velocity.magnitude > 0.8f) m_rigidbody.velocity *= 0.9f;

        // 回転の反映
        transform.rotation = m_UIController.GetRotation();
    }
}
