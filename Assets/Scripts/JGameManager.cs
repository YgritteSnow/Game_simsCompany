using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JGameManager : MonoBehaviour {
    private JUIResources m_resourceRoot;
	static private JGameManager m_instance = null;
	// Use this for initialization
	void Start ()
    {
        Debug.Log("JGameManager start");

		Canvas uiroot = GameObject.Find("UIRoot").GetComponent<Canvas>();
		this.gameObject.AddComponent<JUIResources>();
        m_resourceRoot = GameObject.Find("Helper").GetComponent<JUIResources>();
		m_resourceRoot.Init(uiroot);

        m_resourceRoot.OpenUI("welcome");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	static public JGameManager GetInstance()
	{
		if (!m_instance)
		{
			m_instance = new JGameManager();
		}
		return m_instance;
	}

	static public JUIResources GetJUIResource()
	{
		return m_instance.m_resourceRoot;
	}
}
