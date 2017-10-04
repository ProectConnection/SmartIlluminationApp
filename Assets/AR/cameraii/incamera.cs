using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class incamera : MonoBehaviour {
    public static bool incamflg=false;
    Cam CC;
    [SerializeField]
    GameObject Camera;
	// Use this for initialization
	void Start () {
       CC=GameObject.Find(Camera.name).GetComponent<Cam>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClick()
    {
        if (incamflg == false)
        {
            incamflg=true;
            Debug.Log("" + incamflg);
        }
        else if (incamflg == true)
        {
            incamflg = false;
            Debug.Log("" + incamflg);
        }
        CC.OCamFlg();
        Debug.Log("Click");
    }

}
