using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JPlayer))]
public class J2DPersonController : MonoBehaviour
{
	private JPlayer m_player;

	// Use this for initialization
	void Start()
	{
		m_player = GetComponent<JPlayer>();
		m_player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			m_player.Jump();
		}

		float x = Input.GetAxis("Horizontal");
		m_player.Move(Vector3.right * x);
	}
}
