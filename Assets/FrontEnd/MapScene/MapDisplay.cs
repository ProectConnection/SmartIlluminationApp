using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapDisplay : MonoBehaviour {


    public GameObject Map;

    public bool MapSwitch;

	// Use this for initialization
	void Start () {


        gameObject.SetActive(false);



        MapSwitch = false;

        Map.SetActive(false);


		
	}
	
	// Update is called once per frame
	void Update () {
             
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
