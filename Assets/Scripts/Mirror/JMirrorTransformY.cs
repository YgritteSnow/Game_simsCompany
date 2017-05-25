using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class JMirrorTransformY : MonoBehaviour {
	
	private Transform m_trans;
	// Use this for initialization
	void Start () {
		m_trans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			OnMirror();
		}
	}

	void OnMirror()
	{
		m_trans.Rotate(Vector3.right, 180, Space.World);
	}
}
