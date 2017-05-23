using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMousePicking : MonoBehaviour {

	private GameObject m_lastPicking;
	
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
					if (m_lastPicking && m_lastPicking != hit.transform.gameObject)
						m_lastPicking.GetComponent<JMousePicked>().OnUnPick();
					m_lastPicking = hit.transform.gameObject;
				}
			}
		}

		if (false && Input.GetMouseButtonDown(1))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast(ray, out hit);
			if (hit.transform && hit.transform.gameObject)
			{
				GameObject.Destroy(hit.transform.gameObject);
			}
		}
	}
}
