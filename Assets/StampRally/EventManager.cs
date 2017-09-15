using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {


    public GameObject OK;



	// Use this for initialization
	void Start () {
		

        OK.SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {

            OK.SetActive(true);

        }




    }



    void SpotAreaIN()
    {

       

    }



}
