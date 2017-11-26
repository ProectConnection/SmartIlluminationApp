using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffect : MonoBehaviour {
    [SerializeField]
    GameObject tapEffect;
    [SerializeField]
    Camera _camera;
    private Vector3 ClickCecker;



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
            // Vector3 pos = _camera.ScreenToWorldPoint(Input.mousePosition+_camera.transform.forward*5);//(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            // pos.z = 5;
            //Debug.Log(pos);
            //Debug.Log(Input.mousePosition.y);
            //GameObject EffectFrow = (GameObject)Instantiate(tapEffect, pos,Camera.main.transform.rotation);
            //GameObject EffectFrow = (GameObject)Instantiate(tapEffect, pos, Quaternion.identity);
          
            /*
            //********************
            var parent = this.transform;
             Instantiate(childPrefab, Vector3.zero, Quaternion.identity, parent);
            Instantiate(tapEffect, Vector3.zero, Quaternion.identity, parent);
            //********************
            Destroy(childPrefab, 0.4f);
            Destroy(tapEffect, 0.4f);
            //   tapEffect.transform.position = pos;
            //tapEffect.Emit(1);
            */

        }
    }
}
