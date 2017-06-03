using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTmpResources : MonoBehaviour {
	public struct MonsterInfo
	{
		MonsterInfo(string p, bool c = false){
			id = MonsterInfo._staticID;
			MonsterInfo._staticID += 1;
			path = p;
			canMirror = c;
		}
		int id;
		string path;
		bool canMirror;
		static int _staticID = 1;
	}
	private Dictionary<string, MonsterInfo> m_models_monster;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
