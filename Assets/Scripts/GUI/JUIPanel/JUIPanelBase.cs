using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class JUIPanelBase : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		Debug.Log("JUIPanelBase start");
		OnStart();
		InitHandlers();
	}

	#region Virtual functions for children
	public virtual void OnStart() { }
	public virtual void InitHandlers() { }
	#endregion

	#region AddHandler functions
	public void AddHandler_onClick(string obj_path, UnityEngine.Events.UnityAction call)
	{
		Button obj = GetComponentInChildren<Button>(obj_path);
		if (obj == null) return;

		obj.onClick.AddListener(call);
	}
	public void AddHandler<T>(string obj_path, EventTriggerType trigger_type, UnityEngine.Events.UnityAction<BaseEventData> call)
		where T : Selectable
	{
		T obj = GetComponentInChildren<T>(obj_path);
		if (obj == null) return;

		var trigger = transform.gameObject.GetComponent<EventTrigger>();
		if (trigger == null)
			trigger = transform.gameObject.AddComponent<EventTrigger>();
		var entry = new EventTrigger.Entry();
		entry.eventID = trigger_type;
		entry.callback.AddListener(call);
		trigger.triggers.Add(entry);
	}
	private T GetComponentInChildren<T>(string child_path)
		where T : Component
	{
		Transform tr = this.transform.Find(child_path);
		if (!tr)
		{
			Debug.Log(string.Format("GetComponentInChildren ERROR! Invalid btn_path(%s)", child_path));
			return null;
		}
		T obj = tr.gameObject.GetComponent<T>();
		if (obj == null)
		{
			Debug.Log(string.Format("GetComponentInChildren ERROR! Component %s does not exist in btn_path(%s)!", typeof(T).Name, child_path));
			return null;
		}
		return obj;
	}
	#endregion
}
