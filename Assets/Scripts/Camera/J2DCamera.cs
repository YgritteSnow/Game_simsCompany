using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J2DCamera : MonoBehaviour
{
	public Transform m_followTargetTransform;
	public float m_speed = 0.01f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 new_position = Vector3.Lerp(transform.position, m_followTargetTransform.position, m_speed);
		transform.position = new Vector3(new_position.x, new_position.y, transform.position.z);
	}
}
