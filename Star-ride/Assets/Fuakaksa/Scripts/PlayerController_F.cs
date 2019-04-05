using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_F : MonoBehaviour
{
	private Rigidbody2D m_rigidbody = null;
	private PlayerUIController_F m_controller = null;


	// Start is called before the first frame update
	void Start()
    {
		m_rigidbody = GetComponent<Rigidbody2D>();
		m_controller = GameObject.Find("ControllerUI").GetComponent<PlayerUIController_F>();
    }

    // Update is called once per frame
    void Update()
    {
		m_rigidbody.AddForce(m_controller.GetSendForce(), ForceMode2D.Impulse);

		// 減速処理
		m_rigidbody.velocity *= 0.9f;
    }
}
