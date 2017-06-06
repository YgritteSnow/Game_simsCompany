using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class JMirrorScaleY : JMirrorBase
{

	private Transform m_trans;
	// Use this for initialization
	public override void OnStart()
	{
		m_trans = GetComponent<Transform>();
	}

	public override void OnMirror()
	{
		Vector3 new_scale = m_trans.localScale;
		new_scale.y = -new_scale.y;
		m_trans.localScale = new_scale;
	}
}
