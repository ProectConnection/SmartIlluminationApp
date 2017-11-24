using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffect : MonoBehaviour {
    [SerializeField]
    GameObject tapEffect=null;
    [SerializeField]
    Camera _camera;
    private GameObject _parent;



    //*******************
    [SerializeField]
    GameObject childPrefab;

    //*******************


    // Use this for initialization
    void Start () {
        _parent = GameObject.FindWithTag("MainCamera");

        

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {


         

           // Vector3 pos = Input.mousePosition;
            Vector3 pos = _camera.ScreenToWorldPoint(Input.mousePosition+_camera.transform.forward*5);//(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            Ray touchRay = _camera.ScreenPointToRay(Input.mousePosition);
            Debug.Log(pos);
            Debug.DrawRay(touchRay.origin,touchRay.direction,Color.red,3.0f);
            //Debug.Log(Input.mousePosition.y);
            //GameObject player = (GameObject)Instantiate(tapEffect, pos,Camera.main.transform.rotation);
            //GameObject player = (GameObject)Instantiate(tapEffect, pos, Quaternion.identity);
            //GameObject player = (GameObject)Instantiate(tapEffect, pos, _parent.transform.rotation);
            GameObject player = (GameObject)Instantiate(tapEffect, pos, _parent.transform.rotation);





            //********************
            var parent = this.transform;
             Instantiate(childPrefab, Vector3.zero, Quaternion.identity, parent);
            Instantiate(tapEffect, Vector3.zero, Quaternion.identity, parent);
            //********************






            Destroy(childPrefab, 0.4f);
            Destroy(tapEffect, 0.4f);
            //   tapEffect.transform.position = pos;
            //tapEffect.Emit(1);
        }
	}
}
