using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {




    public GameObject Page1;
    public GameObject Page2;

    public GameObject Next;
    public GameObject Back;

    //public GameObject ViewTutorial;


    // Use this for initialization
    void Start () {

        gameObject.SetActive(false);

        

        Page1.SetActive(true);
        Page2.SetActive(false);

        Next.SetActive(true);
        Back.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

    }


    public void ViewPage()
    {

        gameObject.SetActive(true);

    }



    public void NextPage()
    {

        Page1.SetActive(false);
        Page2.SetActive(true);

        Next.SetActive(false);
        Back.SetActive(true);


    }

    public void BackPage()
    {


        Page1.SetActive(true);
        Page2.SetActive(false);

        Next.SetActive(true);
        Back.SetActive(false);


    }





}
