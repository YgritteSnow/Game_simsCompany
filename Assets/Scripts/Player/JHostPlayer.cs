using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Data;

public class JHostPlayer : MonoBehaviour
{
	private System.Type m_controlerType = typeof(TestPlayerController);
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
}
