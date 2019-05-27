using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class banana : MonoBehaviour
{

    GameObject bananaTime;
    // Use this for initialization
    void Start()
    {
        this.bananaTime = GameObject.Find("BananaTime");
    }

    // Update is called once per frame
    void Update()
    {
        //this.bananaTime.GetComponent<Text>().text = "バナナを食べたかず" + UnitController.m_point.ToString("D1") + "本";

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("arrowmax");
        }
    }
}
