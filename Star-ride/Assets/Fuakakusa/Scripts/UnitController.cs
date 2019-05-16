using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
	private Vector3 m_startPosition;
	private Rigidbody2D m_rigitbody = null;

	// 落下フラグ
	private bool m_isFall;

	// 復活インターバル
	public float m_respawnInterval;
	// 復活までの時間
	private float m_respawnTime = 0.0f;

    // プレイヤーの情報
    private GameObject m_player;

    // Start is called before the first frame update
    void Start()
    {
		// 最初の座標を保存
		m_startPosition = transform.position;

		m_isFall = false;

        // プレイヤーの取得
        m_player = GameObject.Find("ControllerUI");

        // 剛体コンポーネントの取得
        m_rigitbody = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update()
    {
		if (m_isFall)
		{
			Falling();

			// 時間をカウントする
			m_respawnTime += Time.deltaTime;

			if (m_respawnTime > m_respawnInterval)
			{
				// 最初の座標に戻す
				transform.position = m_startPosition;
				// サイズのリセット
				transform.localScale = Vector3.one;
				// 時間のリセット
				m_respawnTime = 0.0f;
				// 落下フラグを戻す
				m_isFall = false;
			}
		}
    }


	// 落下処理
	void Falling()
	{
		// 小さくする
		transform.localScale *= 0.9f;
		// 移動を停止する
		m_rigitbody.velocity = Vector3.zero;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        // 瞬間だけ拡大して表示する
        m_player.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);

        // サイズを戻す
        m_player.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("keep");
        // 瞬間だけ拡大して表示する
        //m_player.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);

        // サイズを戻す
        m_player.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
    }
    
    private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.tag == "Stage")
        {
			// 落下フラグを立てる
			m_isFall = true;
        }
        Debug.Log("out");

        // サイズを戻す
        m_player.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);

    }


	// 落下フラグの取得
	public bool IsFall()
	{
		return m_isFall;
	}


}
