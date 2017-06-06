using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JMirrorBase : MonoBehaviour
{
	public abstract void OnMirror();
	public virtual void OnStart() { }
	void Start()
	{
		Debug.Log("Init:", this);
		JMirrorManager.Instance.RegisterMirror(this);
		OnStart();
	}
	void OnDestroy()
	{
		Debug.Log("UnInit:", this);
		JMirrorManager.Instance.UnRegisterMirror(this);
	}
}

public class JMirrorManager : MonoBehaviour
{

	public JMirrorBase[] m_mirrors;
	private int m_count = 0;
	private int m_capacity = 4;

	public void RegisterMirror(JMirrorBase m)
	{
		foreach(JMirrorBase mb in m_mirrors)
		{
			if(mb == m)
			{
				return;
			}
		}

		if(m_count == m_capacity)
		{
			m_capacity <<= 2;
			JMirrorBase[] new_mirrors = new JMirrorBase[m_capacity];
			m_mirrors.CopyTo(new_mirrors, 0);
			m_mirrors = new_mirrors;
		}
		m_mirrors[m_count] = m;
		m_count++;
	}

	public void UnRegisterMirror(JMirrorBase m)
	{
		for(int i = 0; i < m_count; i++)
		{
			if(m_mirrors[i] == m)
			{
				if (i == m_count - 1)
				{
					m_mirrors[i] = null;
				}
				else
				{
					m_mirrors[i] = m_mirrors[m_count - 1];
 					m_mirrors[m_count-1] = null;
				}
				m_count--;
				return;
			}
		}
	}

	// Use this for initialization
	void Awake()
	{
		m_instance = this;
		m_mirrors = new JMirrorBase[m_capacity];
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			for(int i = 0; i < m_count; ++i)
			{
				m_mirrors[i].OnMirror();
			}
		}
	}

	static private JMirrorManager m_instance;
	static public JMirrorManager Instance { get { return m_instance; } }

}
