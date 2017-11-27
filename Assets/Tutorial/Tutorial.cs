using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {


    public GameObject Page1;
    public GameObject Page2;

    public GameObject Next;
    public GameObject Back;

    private int PageCnt = 0;


    // Use this for initialization
    void Start () {


        Page1.SetActive(true);
        Page2.SetActive(false);

        Next.SetActive(true);
        Back.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

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
