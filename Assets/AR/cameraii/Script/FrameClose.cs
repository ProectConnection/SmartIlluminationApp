using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FrameClose : MonoBehaviour {
    MaterialPropertyBlock block;
    public Menu MN;
	// Use this for initialization
	void Start () {
        block = new MaterialPropertyBlock();
    }
   /* void OnMouseUp()
    {
        GetComponent<Renderer>().SetPropertyBlock(null);
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
       
            return;
        }
        GetComponent<Renderer>().SetPropertyBlock(block);
        if (Input.GetMouseButtonDown(0))
        {
            if (MN.MenuDisplay == true)
            {
                MN.MenuFlg = false;

                MN.MenuDisplay.SetActive(false);
            }
        }
    }*/
        // Update is called once per frame
        void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Renderer>().SetPropertyBlock(null);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {

                return;
            }
            GetComponent<Renderer>().SetPropertyBlock(block);
         
                if (MN.MenuDisplay == true)
                {
                    MN.MenuFlg = false;

                    MN.MenuDisplay.SetActive(false);
                }
        }
    }
}
