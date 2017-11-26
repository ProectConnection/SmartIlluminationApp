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


    //広告表示切り替え
    public void ONPopUpDisplay()
    {
        
            PopUp.SetActive(true);
            
    }
    public void OFFPopUpDisplay()
    {

        PopUp.SetActive(false);

    }
    //


}
