using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JMenuTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[MenuItem("JMenuTest/aaa")]
	public static void aaa()
	{
		Debug.Log("aaa");
	}
}
