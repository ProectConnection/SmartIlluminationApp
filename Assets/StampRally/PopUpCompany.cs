using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpCompany : MonoBehaviour {



    /*
    [SerializeField]
    GameObject[] PopUpList;
    */

    public GameObject PopUp;

    bool DisplayCompany;

    // Use this for initialization
    void Start () {

        PopUp.SetActive(false);
        DisplayCompany = false;
        

    }
	
	// Update is called once per frame
	void Update () {

        /*
        for (int i = 0; i < PopUpList.Length; i++)
        {
            
            PopUpList[i].SetActive(false);
            
        }
        */



    }

    public void ONPopUpDisplay()
    {

        if(DisplayCompany == false)
        {
            PopUp.SetActive(true);
            DisplayCompany = true;
        }
        else if(DisplayCompany == true)
        {
            PopUp.SetActive(false);
            DisplayCompany = false;
        }


       


    }


    /*
    public void PopUpON()
    {

        switch (transform.name)
        {
            case "1":
                PopUpList[0].SetActive(true);
                DisplayCompany = true;
                if(DisplayCompany == true)
                {
                    PopUpList[0].SetActive(false);
                }
                Debug.Log("1");
                break;
            case "2":
                PopUpList[1].SetActive(true);
                DisplayCompany = true;
                if (DisplayCompany == true)
                {
                    PopUpList[1].SetActive(false);
                }
                Debug.Log("2");
                break;
            case "3":
                PopUpList[2].SetActive(true);
                DisplayCompany = true;
                if (DisplayCompany == true)
                {
                    PopUpList[2].SetActive(false);
                }
                Debug.Log("3");
                break;
            case "4":
                PopUpList[3].SetActive(true);
                DisplayCompany = true;
                if (DisplayCompany == true)
                {
                    PopUpList[3].SetActive(false);
                }
                Debug.Log("4");
                break;
            case "5":
                PopUpList[4].SetActive(true);
                DisplayCompany = true;
                if (DisplayCompany == true)
                {
                    PopUpList[4].SetActive(false);
                }
                Debug.Log("5");
                break;
            case "6":
                PopUpList[5].SetActive(true);
                DisplayCompany = true;
                if (DisplayCompany == true)
                {
                    PopUpList[5].SetActive(false);
                }
                Debug.Log("6");
                break;
            default:
                break;
        }

    }
    */

}
