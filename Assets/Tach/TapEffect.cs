using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffect : MonoBehaviour {
    [SerializeField]
    GameObject tapEffect;
    [SerializeField]
    Camera _camera;
    private Vector3 ClickCecker;
   // public GameObject canvasObject;



    //*******************
    //[SerializeField]
    //GameObject childPrefab;

    //*******************


    // Use this for initialization
    void Start () {
  

        

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ClickCecker = Input.mousePosition;
            ClickCecker.z = 5.0f;
            GameObject EffectFrow = (GameObject)Instantiate(tapEffect, _camera.ScreenToWorldPoint(ClickCecker), _camera.transform.rotation);
            Destroy(EffectFrow, 0.4f);
        }
    }
}
