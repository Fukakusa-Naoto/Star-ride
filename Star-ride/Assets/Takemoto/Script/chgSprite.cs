using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chgSprite : MonoBehaviour
{
    // 1枚目の画像
    public Sprite spriteBefore;
    // 2枚目の画像
    public Sprite spriteAfter;
    // 画像を切り替えるフラグ
    private bool chFlg = false;

   
    // 画像を切り替える処理
    public void changeSprite()
    {
        Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

        if (aCollider2d)
        {
            GameObject obj = aCollider2d.transform.gameObject;

            
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteAfter;
            chFlg = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteBefore;
            chFlg = false;
        }
    }

    // スプライトを切り替える関数を呼び出す
    // Update is called once per frame
    void Update()
    {
        if(chFlg == false)
        {
            changeSprite();
            chFlg = false;
        }
        else
        {
            changeSprite();
            chFlg = true;
        }
        
    }
}
