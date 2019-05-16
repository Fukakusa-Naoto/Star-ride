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

    // 拡大時間
    private int m_colNum;
    // 拡大フラグ
    private bool m_colFlag;

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

        // 拡大フラグ
        m_colNum = 0;
        m_colFlag = false;
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

        // 拡大して表示
        if(m_colFlag == true)
        {
            m_colNum++;
            // 30カウント経ったら元のサイズに戻す
            if (m_colNum == 30) 
            {
                // フラグを初期値に戻す
                m_colNum = 0;
                m_colFlag = false;
                // サイズを戻す
                m_player.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
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

    // ぶつかった瞬間
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        // 瞬間だけ拡大して表示する
        m_player.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
        m_colFlag = true;
    }
    
    // 離れた瞬間
    private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.tag == "Stage")
        {
			// 落下フラグを立てる
			m_isFall = true;
        }
        Debug.Log("out");
    }


	// 落下フラグの取得
	public bool IsFall()
	{
		return m_isFall;
	}


}
