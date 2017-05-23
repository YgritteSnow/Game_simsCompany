using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Data;

public class JThirdPersonCharacter : MonoBehaviour
{
	private System.Type m_controlerType = typeof(JFirstPersonController);
	private PlayerInfo m_info;

	// Use this for initialization
	void Start () {
		LoadInfos();
		gameObject.AddComponent(m_controlerType);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadInfos() { }

	public void Move(Vector3 move) { }
}
