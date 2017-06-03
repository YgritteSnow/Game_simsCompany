using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class JMirrorTransformY_playerRef : MonoBehaviour {

	private Transform m_trans;
	private Transform m_playerTrans;
	// Use this for initialization
	void Start () {
		m_trans = GetComponent<Transform>();
		GameObject player = GameObject.Find("Player");
		m_playerTrans = player.GetComponent<Transform>();

		gameObject.tag = JTmpTagManager.Instance.GetTagName(this);
	}

	void OnMirror()
	{
		RaycastHit hit_up, hit_down;
		if(JUtilities.GetCollider_twoSide(out hit_up, out hit_down, m_playerTrans.position, Vector3.down, gameObject))
		{
			Vector3 center = (hit_up.transform.position + hit_down.transform.position) / 2;
			m_trans.RotateAround(center, Vector3.right, 180);
		}
		else
		{
			Debug.Log("Did Not Find!!!");
		}
	}
}
