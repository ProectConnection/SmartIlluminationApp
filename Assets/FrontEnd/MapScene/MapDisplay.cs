using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapDisplay : MonoBehaviour {


    public GameObject Map;

    public bool MapSwitch;

    public GameObject MapCheck;
	// Use this for initialization
	void Start () {


        gameObject.SetActive(false);



        MapSwitch = false;

        Map.SetActive(false);


		
	}
	
	// Update is called once per frame
	void Update () {
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
            if (hit.collider.gameObject != MapCheck)
            {
                //追加項目****************タップされたオブジェクトがMapCheckに入れたオブジェクト出なかったときに以下の処理******************//
                Debug.Log("trueですね");
                Map.SetActive(false);
                MapSwitch = false;
                Debug.Log("てすてす" + hit.collider.gameObject.name);
            }
            }
          
        
	}


    public void MapButtonView()
    {

        gameObject.SetActive(true);

    }

    public void SwitchDisplayMap()
    {


        if (MapSwitch == false)
        {

            Map.SetActive(true);
            MapSwitch = true;

        }
        else if (MapSwitch == true)
        {

            Map.SetActive(false);
            MapSwitch = false;
        }

    }
}
