using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // ＋１の情報
    private Image m_plusOne;

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

        // ＋１プレイヤーの取得
        m_plusOne = GameObject.Find("Canvas/Plus1").GetComponent<Image>();
        // ＋１の非表示
        m_plusOne.enabled = false;

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
                m_player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
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

                // ＋１の非表示
                m_plusOne.enabled = false;
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
        // 瞬間だけ拡大して表示する
        m_player.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
        m_colFlag = true;

        // ＋１の表示
        m_plusOne.enabled = true;
    }
    
    // 離れた瞬間
    private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.tag == "Stage")
        {
			// 落下フラグを立てる
			m_isFall = true;
        }
    }


	// 落下フラグの取得
	public bool IsFall()
	{
		return m_isFall;
	}


}
