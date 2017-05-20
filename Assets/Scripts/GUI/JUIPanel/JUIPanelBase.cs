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
	}

	public virtual void OnStart() {}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void OnClickButton()
	{
		Debug.Log("on click");
		SceneManager.LoadScene("home", LoadSceneMode.Single);
	}
}
