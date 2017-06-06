using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTmpTagManager : MonoBehaviour {
	JTmpTagManager()
	{
		m_tags.Add(typeof(JMirrorTransformY), "JMirrorTransformY");
		m_tags.Add(typeof(JMirrorTransformY_playerRef), "JMirrorTransformY_playerRef");
		m_tags.Add(typeof(JMirrorScaleY), "JMirrorScaleY");
		foreach (KeyValuePair<System.Type, string> i in m_tags)
		{
			Debug.Log("Init - "+i.Value);
		}
	}

	static private JTmpTagManager m_instance = null;
	private void Awake()
	{
		Debug.Log("JGameManager awake");
		m_instance = this;
	}
	static public JTmpTagManager Instance { get { return m_instance; } }

	private Dictionary<System.Type, string> m_tags = new Dictionary<System.Type, string>();
	// Use this for initialization
	void Start () {
	}

	public string GetTagName<T>()
	{
		return m_tags[typeof(T)];
	}

	public string GetTagName<T>(T t)
	{
		Debug.Log(string.Format("GetTagName:{0},{1}",t.ToString(), typeof(T).ToString()));
		foreach(KeyValuePair<System.Type, string> i in m_tags)
		{
			Debug.Log("loop - "+ typeof(T)+","+i.Value);
		}
		return m_tags[typeof(T)];
	}
}
