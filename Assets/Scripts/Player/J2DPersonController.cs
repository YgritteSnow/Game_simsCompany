using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class J2DPersonController : MonoBehaviour
{
	public float m_speed = 5.0f;
	public float m_jump = 5.0f;

	public bool m_isJumping = false;

	private Rigidbody m_rigid;
	// Use this for initialization
	void Start()
	{
		m_rigid = GetComponent<Rigidbody>();
		m_rigid.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
	}

	// Update is called once per frame
	void Update()
	{
		if (!m_isJumping)
		{
			if(Input.GetKeyDown(KeyCode.W))
			{
				m_rigid.AddForce(Vector3.up * m_jump, ForceMode.VelocityChange);
				m_isJumping = true;
			}
		}

		float x = Input.GetAxis("Horizontal");
		m_rigid.AddForce(Vector3.right * x * m_speed, ForceMode.Acceleration);
	}
}
