//__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/
//! @file		EnemyController.cs
//!
//! @summary	敵の制御に関するC#スクリプト
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
public class EnemyController : MonoBehaviour
{
    // <メンバ変数>
    // 攻撃のインターバル
    private float m_attackInterval = 3.0f;
    // 攻撃までの時間
    private float m_attackTime = 0.0f;
    // プレイヤーの情報
    private GameObject m_player;
    // チャージ時間
    private float m_sinkValue = 5.0f;
    // ユニットコントローラー
    private UnitController m_unitController = null;
    // 剛体コンポーネント
    private Rigidbody2D m_rigidbody = null;

    // 開始時間
    private int m_cntTime = 0;


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
        // プレイヤーの取得
        m_player = GameObject.FindGameObjectWithTag("Player");
        // ユニットコントローラーの取得
        m_unitController = GetComponent<UnitController>();
        // 剛体コンポーネントの取得
        m_rigidbody = GetComponent<Rigidbody2D>();
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
        // 3秒開始を遅らせる
        if (m_cntTime < 180)
        {
            m_cntTime++;
        }

        
        // 落下フラグが立っていたら処理を中止
        if (m_unitController.IsFall())
        {
            m_attackTime = 0.0f;
            return;
        }

        // 3秒経っていたら
        if (m_cntTime >= 180)
        {
            // 攻撃時間の更新
            m_attackTime += Time.deltaTime;

            if (m_attackTime > m_attackInterval)
            {
                // 方向を求める
                Vector3 direction = m_player.transform.position - transform.position;
                // 力を加える
                m_rigidbody.AddForce(direction.normalized * m_sinkValue, ForceMode2D.Impulse);
                // 回転させる
                float angle = Mathf.Atan2(direction.y, direction.x);
                transform.rotation = Quaternion.Euler(0, 0, (angle * Mathf.Rad2Deg) - 90.0f);

                // 攻撃時間をリセットする
                m_attackTime = 0.0f;
            }
        }
    }
}
