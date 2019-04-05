using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController_F : MonoBehaviour
{
	// 最大付与力量
	private const float MaxMagnitude = 5.0f;

	// 溜めた値
	private float m_sinkValue=0;
	// 送る力
	private Vector2 m_sendForce = Vector2.zero;

	// 発射方向
	[SerializeField]
	private Vector3 m_direction = Vector3.zero;

	// 発射方向の力
	private Vector3 m_currentForce = Vector3.zero;

	// メインカメラ
	private Camera m_mainCamera = null;

	// メインカメラ座標
	private Transform m_mainCameraTransform = null;

	// ドラッグ開始点
	private Vector3 m_dragStart = Vector3.zero;


	// Start is called before the first frame update
	void Start()
    {
        m_mainCamera = Camera.main;
        m_mainCameraTransform = m_mainCamera.transform;
    }


	private void FixedUpdate()
	{
		m_sendForce = Vector2.zero;
	}


	/// <summary>
	/// マウス座標をワールド座標に変換して取得
	/// </summary>
	/// <returns></returns>
	private Vector3 GetMousePosition()
	{
		// マウスから取得できないZ座標を補完する
		var position = Input.mousePosition;
		position.z = m_mainCameraTransform.position.z;
		position = m_mainCamera.ScreenToWorldPoint(position);
		position.z = 0;

		return position;
	}

	/// <summary>
	/// ドラック開始イベントハンドラ
	/// </summary>
	public void OnMouseDown()
	{
		Debug.Log("ドラック開始イベント");

		m_dragStart = this.GetMousePosition();
	}

	/// <summary>
	/// ドラッグ中イベントハンドラ
	/// </summary>
	public void OnMouseDrag()
	{
		var position = this.GetMousePosition();
		Debug.Log(position);

		m_currentForce = position - m_dragStart;
		if (m_currentForce.magnitude > MaxMagnitude * MaxMagnitude)
		{
			m_currentForce *= MaxMagnitude / m_currentForce.magnitude;
		}
		Debug.Log(m_currentForce);
	}

	/// <summary>
	/// ドラッグ終了イベントハンドラ
	/// </summary>
	public void OnMouseUp()
	{
		Debug.Log("ドラック終了イベント");

		m_sendForce = m_currentForce;
	}


	public Vector2 GetSendForce()
	{
		//Debug.Log(m_sendForce);
		return m_sendForce;
	}
}
