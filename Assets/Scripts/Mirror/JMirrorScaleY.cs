using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class JMirrorScaleY : MonoBehaviour
{

	private Transform m_trans;
	// Use this for initialization
	void Start()
	{
		m_trans = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			OnMirror();
		}
	}

	void OnMirror()
	{
		Vector3 new_scale = m_trans.localScale;
		new_scale.y = -new_scale.y;
		m_trans.localScale = new_scale;
	}
}
