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
            Debug.Log("押しているのだが");
            if (EventSystem.current.IsPointerOverGameObject())
            {

                return;
            }
            GetComponent<Renderer>().SetPropertyBlock(block);

            if (MD.Map == true)
            {
                MD.MapSwitch = false;

                MD.Map.SetActive(false);
            }
        }
	}
}
