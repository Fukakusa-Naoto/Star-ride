using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : MonoBehaviour
{
    public Transform target;    //追いかける対象 -オブジェクトをインスペクタから登録できるように
    public float speed = 0.1f;  //移動スピード
    private Vector3 vec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation,
        //    Quaternion.LookRotation(target.position - transform.position), 0.3f);

        ////targetに向かって進む
        //transform.position += transform.forward * speed;

        this.transform.position = Vector2.MoveTowards(this.transform.position, 
            new Vector2(target.transform.position.x, target.transform.position.y), speed * Time.deltaTime);

    }
}
