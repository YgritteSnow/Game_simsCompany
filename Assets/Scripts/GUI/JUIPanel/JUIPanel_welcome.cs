using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JUIPanel_welcome : JUIPanelBase {

	// Use this for initialization
	public override void OnStart () {
		Debug.Log("JUIPanel_welcome start");
    }

	public override void InitHandlers()
	{
		AddHandler_onClick("Button_Red", () =>
		{
			SceneManager.LoadScene("home");
		});
	}
}
