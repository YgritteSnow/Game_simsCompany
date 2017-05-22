using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMousePicking : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast(ray, out hit);
			if (hit.transform && hit.transform.gameObject)
			{
				JMousePicked picked = hit.transform.gameObject.GetComponent<JMousePicked>();
				if (picked)
				{
					picked.OnPick();
				}
			}
		}
	}
}
