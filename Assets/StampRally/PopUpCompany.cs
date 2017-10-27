using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PopUpCompany : MonoBehaviour
{

    public GameObject PopUp;

    bool DisplayCompany;
    bool DoubleFlg;

    // Use this for initialization
    void Start()
    {
        PopUp.SetActive(false);
        DisplayCompany = false;
        DoubleFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ONPopUpDisplay()
    {
        if (DisplayCompany == false)
        {
            PopUp.SetActive(true);
            DisplayCompany = true;
            
            //Debug.Log("開いた");
        }
        else if (DisplayCompany == true)
        {
            PopUp.SetActive(false);
            DisplayCompany = false;
            
            //Debug.Log("閉じた");
        }
    }


   

}
