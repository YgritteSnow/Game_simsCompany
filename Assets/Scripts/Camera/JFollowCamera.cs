using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class JFollowCamera : MonoBehaviour {
	public Transform m_followTargetTransform;
	public float m_zoomSpeed = 2.0f;
	public float m_rotateSpeed = 4.0f;
	public float m_followSpeed = 0.99f;
	public float m_distance = 4.0f;

	private Transform m_transform;

	// Use this for initialization
	void Start () {
		m_transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void LateUpdate()
	{
		if (Input.GetKey(KeyCode.Mouse1))
		{
			float h = Input.GetAxis("Mouse X");
			float v = Input.GetAxis("Mouse Y");
			RotateCamera(h, v);
		}

		RefreshFollowDist();
		ZoomCamera(Input.GetAxis("Mouse ScrollWheel"));
	}

	private void RefreshFollowDist()
	{
		float dist = Mathf.Lerp(m_distance, (m_followTargetTransform.position - m_transform.position).magnitude, m_followSpeed);
		m_transform.position = m_followTargetTransform.position - m_transform.forward * dist;
	}

	private void RotateCamera(float x, float y)
	{
		m_transform.Rotate(0, x * m_rotateSpeed, 0, Space.World);
		m_transform.Rotate(-y * m_rotateSpeed, 0, 0, Space.Self);
	}

	private void ZoomCamera(float dist)
	{
		m_distance -= dist * m_zoomSpeed;
	}
}
