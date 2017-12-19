using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapClose : MonoBehaviour {
    MaterialPropertyBlock block;
    public MapDisplay MD;
    // Use this for initialization
    void Start () {
        block = new MaterialPropertyBlock();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Renderer>().SetPropertyBlock(null);
        }

        if (Input.GetMouseButtonDown(0))
        {


            GetComponent<Renderer>().SetPropertyBlock(block);
            //******  PCでデバッグをする場合以下の1f文を右のように変えてください　→　if (EventSystem.current.IsPointerOverGameObject()) ******//
            //2017/12/19 大塚追記　エディタでデバッグする時に判定式が変わるように変更
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.OSXEditor:
                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        return;
                    }
                    break;
                default:
                    if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                    {

                        return;
                    }
                    break;
                    
            }
            
            
            

            if (MD.Map == true)
            {
                MD.MapSwitch = false;

                MD.Map.SetActive(false);
            }
        }
	}
}
