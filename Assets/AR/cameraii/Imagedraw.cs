using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imagedraw : MonoBehaviour {
    [SerializeField]
    Texture2D[] tempphotoframe;
    [SerializeField]
    Transform pealentTransform;
    
    public GameObject img;
    //public GameObject SpotManagerGObject;
    // Use this for initialization
    void Start () {
        //nearestSpotoDataがnullかを確認する処理を追加
        // tempphotoframe = GameObject.FindGameObjectWithTag("SpotManager").GetComponent<SpotManager>().nearestSpotData.photoFrames;
      GameObject  SpotManagerGObject = GameObject.FindGameObjectWithTag("SpotManager");
        if (SpotManagerGObject != null)
        {
            SpotData nearSpotdata = SpotManagerGObject.GetComponent<SpotManager>().nearestSpotData;
            if (nearSpotdata != null) tempphotoframe = nearSpotdata.photoFrames;
            foreach (Texture2D frame in tempphotoframe)
            {
                //Imageのプレハブ生成
                Instantiate(img,pealentTransform);
            }
        }
        
	}
	
	// Update is called once per frame
	void Update () {
       
    }
}
