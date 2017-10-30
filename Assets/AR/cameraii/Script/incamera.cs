using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class incamera : MonoBehaviour {
    
    [SerializeField]
    GameObject Camera;
	// Use this for initialization
	void Start () {
        Camera = GameObject.FindWithTag("maincam");
	}
	
	// Update is called once per frame
	void Update () {
        //Cam.CameraFlg = false;
        //OnClick();
	}
    public void OnClick()
    {

        
        Cam.CameraFlg = !Cam.CameraFlg;
       Debug.Log(Cam.CameraFlg);
    }

}
