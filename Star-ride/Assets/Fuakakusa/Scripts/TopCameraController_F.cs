//__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/
//! @file		TopCameraController.cs
//!
//! @summary	プレイヤーを制御するUIの制御に関するC#スクリプト
//!
//! @date		2019.04.05
//!
//! @author		深草直斗
//__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/

// 名前空間の省略 ===========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// クラスの定義 =============================================================
public class TopCameraController_F : MonoBehaviour
{
	public GameObject m_target;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		Vector3 pos = m_target.transform.position;
		transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}
