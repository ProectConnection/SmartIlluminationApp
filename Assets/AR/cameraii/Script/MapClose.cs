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
            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
            {

                return;
            }
            

            if (MD.Map == true)
            {
                MD.MapSwitch = false;

                MD.Map.SetActive(false);
            }
        }
	}
}
