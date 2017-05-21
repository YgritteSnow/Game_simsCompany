using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JGameManager : MonoBehaviour
{
	public Canvas m_UIRoot;

	private JUIResources m_resourceRoot;
	static private JGameManager m_instance = null;
	// Use this for initialization
	void Start ()
    {
        Debug.Log("JGameManager start");
		if (!m_UIRoot) return;

		m_resourceRoot = this.gameObject.AddComponent<JUIResources>();
		m_resourceRoot.Init(m_UIRoot);

        m_resourceRoot.OpenUI("welcome");
	}

	private void Awake()
	{
		Debug.Log("JGameManager awake");
		m_instance = this;
	}
	static public JGameManager Instance { get { return m_instance; } }

	static public JUIResources GetJUIResource()
	{
		return m_instance.m_resourceRoot;
	}
}
