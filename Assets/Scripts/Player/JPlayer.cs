using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

[RequireComponent(typeof(Rigidbody))]
public class JPlayer : MonoBehaviour
{
	public float m_speed = 5.0f;
	public float m_jump = 5.0f;
	public bool m_isJumping = false;

	public float m_groundCheckDistance = 0.8f;
	private Vector3 m_groundNormal;
	public bool m_isGrounded;

	private Rigidbody m_rigid;


	// Use this for initialization
	void Start ()
	{
		m_rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateGroundStatus();
	}

	public void Jump()
	{
		if (!m_isJumping)
		{
			m_rigid.AddForce(Vector3.up * m_jump, ForceMode.VelocityChange);
			m_isJumping = true;
		}
	}

	public void Move(Vector3 direct)
	{
		if (!m_isGrounded)
			return;
		Vector3 new_velocity = direct * m_speed;
		new_velocity.y = m_rigid.velocity.y;
		m_rigid.velocity = new_velocity;
		//m_rigid.AddForce(direct * m_speed, ForceMode.Acceleration);
	}

	void UpdateGroundStatus()
	{
		RaycastHit hitInfo;
		if (JUtilities.GetCollider_one_forceDist(out hitInfo, transform.position, Vector3.down, m_groundCheckDistance))
		{
			m_groundNormal = hitInfo.normal;
			m_isGrounded = true;
			m_isJumping = false;
		}
		else
		{
			m_isGrounded = false;
			m_groundNormal = Vector3.up;
		}
	}
}
