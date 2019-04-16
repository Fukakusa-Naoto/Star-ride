using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_F : MonoBehaviour
{
	private Rigidbody2D m_rigidbody = null;
	private PlayerUIController_F m_UIController = null;
	private UnitController m_UnitController = null;


	// Start is called before the first frame update
	void Start()
    {
		m_rigidbody = GetComponent<Rigidbody2D>();
		m_UIController = GameObject.Find("ControllerUI").GetComponent<PlayerUIController_F>();
		m_UnitController = GetComponent<UnitController>();
	}

    // Update is called once per frame
    void Update()
    {
		// 落下フラグが立っていたら更新しない
		if (m_UnitController.IsFall()) return;

		m_rigidbody.AddForce(m_UIController.GetSendForce(), ForceMode2D.Impulse);

		// 減速処理
		if (m_rigidbody.velocity.magnitude > 0.8f) m_rigidbody.velocity *= 0.9f;

		// 回転の反映
		transform.rotation = m_UIController.GetRotation();
    }
}
