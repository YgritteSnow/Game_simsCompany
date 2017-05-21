using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUIResources : MonoBehaviour {
    #region Data
    private Canvas m_UIRoot;

    // structure of gui resources
    public struct JUIResourceData
    {
        public string name;
        public string prefab_path;
        public System.Type script_type;
        public JUIResourceData(string n, string p, System.Type c) {
            this.name = n;
            this.prefab_path = p;
            this.script_type = c;
        }
    }
    // a collection of all gui
    private Dictionary<string, JUIResourceData> m_ResPath = new Dictionary<string, JUIResourceData>();

	#endregion

	#region Register UI resources
	// Register all gui names at start
	public void Init (Canvas uiroot)
    {
        Debug.Log("JUIResources Init");
		this.m_UIRoot = uiroot;
        //RegisterUI<JUIPanel_welcome>("welcome", "Assets/Resources/Prefabs/UI/UIPanel/panel_welcome.prefab");
        RegisterUI<JUIPanel_welcome>("welcome", "Prefabs/UI/UIPanel/panel_welcome");
    }
    
    void RegisterUI<T>(string name, string prefab_path) {
        m_ResPath.Add(name, new JUIResourceData(name, prefab_path, typeof(JUIPanel_welcome)));
    }

    private JUIResourceData GetUIInfo(string name)
    {
        if (!m_ResPath.ContainsKey(name))
        {
            return new JUIResourceData("","",typeof(JUIPanelBase));
        }
        else
        {
            return m_ResPath[name];
        }
    }
	#endregion

	#region Public functions provided
	public void OpenUI(string name)
    {
        JUIResourceData info = GetUIInfo(name);
        GameObject uiobj = Resources.Load(info.prefab_path) as GameObject;
        if (!uiobj)
        {
            Debug.Log("Invalid UI name:" + name + "," + info.prefab_path);
            return;
        }

		//GameObject uiobj_tmp = GameObject.Instantiate(uiobj, m_UIRoot.transform);
		GameObject uiobj_tmp = GameObject.Instantiate(uiobj, new Vector3(), new Quaternion(), m_UIRoot.transform);
        uiobj_tmp.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
		uiobj_tmp.AddComponent(info.script_type);
    }
    #endregion
}