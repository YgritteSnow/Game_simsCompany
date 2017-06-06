using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class JMirrorTransformY : JMirrorBase
{
	private Transform m_trans;
	// Use this for initialization
	public override void OnStart () {
		m_trans = GetComponent<Transform>();
	}

	public override void OnMirror()
	{
		m_trans.Rotate(Vector3.right, 180, Space.World);
	}
}
