using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTmpTagManager : MonoBehaviour {

	static private JTmpTagManager m_instance = null;
	private void Awake()
	{
		Debug.Log("JGameManager awake");
		m_instance = this;
	}
	static public JTmpTagManager Instance { get { return m_instance; } }

	private Dictionary<System.Type, string> m_tags;
	// Use this for initialization
	void Start () {
		m_tags.Add(typeof(JMirrorTransformY), "JMirrorTransformY");
		m_tags.Add(typeof(JMirrorTransformY_playerRef), "JMirrorTransformY_playerRef");
		m_tags.Add(typeof(JMirrorScaleY), "JMirrorScaleY");
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			foreach (KeyValuePair<System.Type, string> i in m_tags)
			{
				System.Reflection.MethodBase d = i.Key.DeclaringMethod;
				dynamic t = d.Invoke("", FindObjectsOfType(i.Key));
				foreach (dynamic hinge in t)
				{
					hinge.onMirror();
				}
			}
		}
	}

	public string GetTagName<T>()
	{
		return m_tags[typeof(T)];
	}

	public string GetTagName<T>(T t)
	{
		return m_tags[typeof(T)];
	}
}
