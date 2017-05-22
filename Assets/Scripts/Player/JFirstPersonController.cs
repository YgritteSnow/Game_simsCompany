using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JFirstPersonController : MonoBehaviour{
	public float m_speed = 5.0f;
	public Transform m_curCameraTransform;

	private Rigidbody m_rigid;
	// Use this for initialization
	void Start () {
		m_rigid = GetComponent<Rigidbody>();
		if (!m_curCameraTransform)
		{
			GameObject camera = GameObject.Find("Main Camera");
			if (!camera) return;
			m_curCameraTransform = camera.GetComponent<Transform>();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		if (x != 0 || y != 0)
		{
			Vector3 dir = m_curCameraTransform.right * x + m_curCameraTransform.forward * y;
			dir.Normalize();
			AddCameraForce(dir);
		}
	}

	private void AddCameraForce(Vector3 direct)
	{
		m_rigid.AddForce(direct*m_speed, ForceMode.Acceleration);
	}
}
