using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUIResources : MonoBehaviour {
    #region Data
    public Canvas UIRoot;

    // structure of gui resources
    public struct JUIResourceData
    {
        public string name;
        public string prefab_path;
        public int component_id;
        public JUIResourceData(string n, string p, int c) {
            this.name = n;
            this.prefab_path = p;
            this.component_id = c;
        }
    }
    // a collection of all gui
    private Dictionary<string, JUIResourceData> m_ResPath = new Dictionary<string, JUIResourceData>();

    #endregion

    // Register all gui names at start
    void Start ()
    {
        Debug.Log("JUIResources start");
        //RegisterUI<JUIPanel_welcome>("welcome", "Assets/Resources/Prefabs/UI/UIPanel/panel_welcome.prefab");
        RegisterUI<JUIPanel_welcome>("welcome", "Prefabs/UI/UIPanel/panel_welcome");
    }
    
    void RegisterUI<T>(string name, string prefab_path) {
        m_ResPath.Add(name, new JUIResourceData(name, prefab_path, 1));
    }

    JUIResourceData GetUIInfo(string name)
    {
        if (!m_ResPath.ContainsKey(name))
        {

            return new JUIResourceData("","",0);
        }
        else
        {
            return m_ResPath[name];
        }
    }

    #region Public functions
    public void OpenUI(string name)
    {
        JUIResourceData info = GetUIInfo(name);
        GameObject uiobj = Resources.Load(info.prefab_path) as GameObject;
        if (!uiobj)
        {
            Debug.Log("Invalid UI name:" + name);
            return;
        }

        //GameObject uiobj_tmp = GameObject.Instantiate(uiobj, UIRoot.transform);
        GameObject uiobj_tmp = GameObject.Instantiate(uiobj, new Vector3(), new Quaternion(), UIRoot.transform);
        uiobj_tmp.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);

        if(name == "welcome")
        {
            uiobj_tmp.AddComponent<JUIPanel_welcome>();
        }
    }
    #endregion

    // RTTI
}