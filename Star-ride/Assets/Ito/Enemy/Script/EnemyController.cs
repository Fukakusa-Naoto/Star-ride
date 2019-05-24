using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
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


    // Start is called before the first frame update
    void Start()
    {
		// プレイヤーの取得
		m_player = GameObject.FindGameObjectWithTag("Player");
		// ユニットコントローラーの取得
		m_unitController = GetComponent<UnitController>();
		// 剛体コンポーネントの取得
		m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		// 落下フラグが立っていたら処理を中止
		if (m_unitController.IsFall())
		{
			m_attackTime = 0.0f;
			return;
		}


		// 攻撃時間の更新
		m_attackTime += Time.deltaTime;

		if(m_attackTime>m_attackInterval)
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
