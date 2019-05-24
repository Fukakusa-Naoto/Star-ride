using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlay : MonoBehaviour
{
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // マウスの左をクリックしたとき
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            // マウスが触れたとき
            if (hit2d)
            {
                if (hit2d.transform.name == "Revenge")
                {
                   SceneManager.LoadScene("GameScene");
                }
            }
        }
    }

}
