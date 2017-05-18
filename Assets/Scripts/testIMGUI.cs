using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testIMGUI : MonoBehaviour {
    public Texture tex;
    public GUIStyle style;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnGUI()
    {
        // This line feeds "This is the tooltip" into GUI.tooltip
        GUI.Button(new Rect(10, 10, 100, 20), new GUIContent("1111", tex, "This is the tooltip 111"), style);
        GUI.Label(new Rect(10, 40, 100, 20), GUI.tooltip);

        GUI.Button(new Rect(10, 40, 100, 20), new GUIContent("2222", tex, "This is the tooltip 222"), style);
        GUI.Label(new Rect(10, 70, 100, 20), GUI.tooltip);
    }
}
