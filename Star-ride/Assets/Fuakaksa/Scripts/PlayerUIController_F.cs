//__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/__/
//! @file		PlayerUIController_F.cs
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
public class PlayerUIController_F : MonoBehaviour
{
	// <メンバ定数>
	// 最大付与力量
	private const float MAX_MAGNITUDE = 5.0f;

	// <メンバ変数>
	// 溜めた値
	private float m_sinkValue = 0;
	// 送る力
	private Vector2 m_sendForce = Vector2.zero;
	// 発射方向の力
	private Vector3 m_currentForce = Vector3.zero;
	// メインカメラ
	private Camera m_mainCamera = null;
	// メインカメラ座標
	private Transform m_mainCameraTransform = null;
	// ドラッグ開始点
	private Vector3 m_dragStart = Vector3.zero;


	// メンバ関数の定義 =====================================================
	//--------------------------------------------------------------------
	//! @summary   初期化処理
	//!
	//! @parameter [void] なし
	//!
	//! @return    なし
	//--------------------------------------------------------------------
	void Start()
    {
		// カメラの取得
        m_mainCamera = Camera.main;
		// カメラの座標情報の取得
        m_mainCameraTransform = m_mainCamera.transform;
    }



	//--------------------------------------------------------------------
	//! @summary   更新処理
	//!
	//! @parameter [void] なし
	//!
	//! @return    なし
	//--------------------------------------------------------------------
	private void FixedUpdate()
	{
		// 送る力をリセットする
		m_sendForce = Vector2.zero;
	}



	//--------------------------------------------------------------------
	//! @summary   マウス座標をワールド座標に変換して取得
	//!
	//! @parameter [void] なし
	//!
	//! @return    変換後の座標
	//--------------------------------------------------------------------
	private Vector3 GetMousePosition()
	{
		// マウスから取得できないZ座標を補完する
		Vector3 position = Input.mousePosition;
		position.z = m_mainCameraTransform.position.z;
		position = m_mainCamera.ScreenToWorldPoint(position);

		// Z座標は使わないので0にする
		position.z = 0.0f;

		return position;
	}



	//--------------------------------------------------------------------
	//! @summary   ドラック開始イベントハンドラ
	//!
	//! @parameter [void] なし
	//!
	//! @return    なし
	//--------------------------------------------------------------------
	public void OnMouseDown()
	{
		m_dragStart = this.GetMousePosition();
	}

	/// <summary>
	/// ドラッグ中イベントハンドラ
	/// </summary>
	public void OnMouseDrag()
	{
		var position = this.GetMousePosition();

		m_currentForce = position - m_dragStart;
		if (m_currentForce.magnitude > MAX_MAGNITUDE * MAX_MAGNITUDE)
		{
			m_currentForce *= MAX_MAGNITUDE / m_currentForce.magnitude;
		}
	}

	/// <summary>
	/// ドラッグ終了イベントハンドラ
	/// </summary>
	public void OnMouseUp()
	{
		m_sendForce = m_currentForce;
	}


	public Vector2 GetSendForce()
	{
		return m_sendForce;
	}
}
