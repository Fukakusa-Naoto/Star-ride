using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayDirector : MonoBehaviour
{
    public AudioClip startse;
    AudioSource aud;
    // 拡大
    float x = 0.01f;
    float y = 0.01f;

    // 経過時間
    float seconds;
     
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        seconds = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // マウスのクリック判定を取得し、次のシーンをロードする
        if (Input.GetMouseButtonDown(0))
        {
            // 効果音
            GetComponent<AudioSource>().Play();

            Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

            // マウスとスタートボタンの当たり判定
            if (aCollider2d)
            {
                GameObject obj = aCollider2d.transform.gameObject;
            }

            // ""の関数を呼び出す
            Invoke("DelayMethod", 1f);
            
        }
        Scale(x, y);
       
        // 経過時間をカウント
        seconds += Time.deltaTime;
    }

    // 2秒後にゲームシーンに移行
    void DelayMethod()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    
    void Scale(float x, float y)
    {
        // 始まってすぐ拡大
        if(seconds <= 1.5f)
        {
            gameObject.transform.localScale += new Vector3(x, y);
        }

        // 2秒後に画像を縮小
        if (seconds >= 1.5f)
        {
            // 縮小
            gameObject.transform.localScale -= new Vector3(x, y);
        }
        
        // 4秒経過で0秒に戻す
        if(seconds >= 3f)
        {
            seconds = 0f;
        }
    }
}
