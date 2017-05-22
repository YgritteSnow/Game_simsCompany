using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class JMousePicked : MonoBehaviour {
	public Color m_selectedColor;
	private bool m_isPicked;
	private Material m_material;
	private Color m_originColor;
	// Use this for initialization
	void Start () {
		m_material = GetComponent<Renderer>().material;
		m_originColor = m_material.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPick()
	{
		m_isPicked = !m_isPicked;
		m_material.SetColor("_Color", m_isPicked ? m_selectedColor : m_originColor);
	}
}
