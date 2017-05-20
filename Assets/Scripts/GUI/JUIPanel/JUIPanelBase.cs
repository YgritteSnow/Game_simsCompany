using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JUIPanelBase : MonoBehaviour {
	// Use this for initialization
	void Start ()
	{
		Debug.Log("JUIPanelBase start");
		Button btn = this.GetComponent<Button>();
		if (!btn)
		{
			Debug.Log("no btn");
		}
		else
		{
			btn.onClick.AddListener(OnClickButton);
		}
		OnStart();
		InitHandlers();
	}

	#region Virtual functions for children
	public virtual void OnStart() {}
	public virtual void InitHandlers() {}
	#endregion

	public void AddHandler_onclick<T>(string btn_path, UnityEngine.Events.UnityAction call)
		where T : Button
	{
		Transform tr = this.transform.Find(btn_path);
		if (!tr)
		{
			Debug.Log(string.Format("ERROR! AddHandler: invalid btn_path(%s)", btn_path));
		}
		T obj = tr.gameObject.GetComponent<T>();
		if (obj == null)
		{
			Debug.Log(string.Format("ERROR! Component %s does not exist in btn_path(%s)!", typeof(T).Name, btn_path));
		}
		obj.onClick.AddListener(call);
	}
	public virtual void OnClickButton()
	{
		Debug.Log("on click");
		SceneManager.LoadScene("home", LoadSceneMode.Single);
	}
}
