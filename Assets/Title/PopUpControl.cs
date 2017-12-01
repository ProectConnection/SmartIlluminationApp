using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpControl : MonoBehaviour {


    //ポップアップの表示・非表示に関する動き

    public GameObject PopUp;


    
    // Use this for initialization
    void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {



    }

    public void Unlock()
    {

       
        Destroy(PopUp);

    }





}
