using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Deb_TouchLamp : MonoBehaviour {

    Image thisImage;


    // Use this for initialization
    void Start () {
        thisImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        thisImage.enabled = (Input.touchCount > 0) ? true : false;
	}
};