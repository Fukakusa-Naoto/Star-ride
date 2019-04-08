using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayDirector : MonoBehaviour
{
    public AudioClip startse;
    AudioSource aud;
     
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
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
            Invoke("DelayMethod", 2f);
        }
    }

    // 2秒後にゲームシーンに移行
    void DelayMethod()
    {
        SceneManager.LoadScene("GameScene");
    }
    

}
