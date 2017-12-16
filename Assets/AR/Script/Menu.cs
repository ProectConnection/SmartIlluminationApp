using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour {


    public GameObject MenuDisplay;


   public bool MenuFlg;


    // Use this for initialization
    void Start () {

        MenuDisplay.SetActive(false);
        MenuFlg = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    public void OnMenu()
    {
        if (MenuFlg == false)
        {
            MenuDisplay.SetActive(true);
            MenuFlg = true;

        }
        else if(MenuFlg == true)
        {
            MenuDisplay.SetActive(false);
            MenuFlg = false;
        }

    }

    public void OnFrame()
    {



    }


}
