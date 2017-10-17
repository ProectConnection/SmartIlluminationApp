using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PopUpCompany : MonoBehaviour
{

    [SerializeField]
    GameObject[] PopUp;

    /*
    public GameObject Pop1;
    public GameObject Pop2;
    public GameObject Pop3;
    */


    int j;



    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        /*
        Pop1.SetActive(false);
        Pop2.SetActive(false);
        Pop3.SetActive(false);
        */


        CompanydisplayON();




    }


    public void CompanydisplayON()
    {

        for (j = 0; j < PopUp.Length; j++)
        {
            PopUp[j].SetActive(false);
        }



    }

    public void OnDisplayCompany()
    {

        for (j = 0; j < PopUp.Length; j++)
        {
            PopUp[1].SetActive(false);
        }

    }

}