using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
