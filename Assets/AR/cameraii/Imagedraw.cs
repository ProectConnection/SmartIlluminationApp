using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Imagedraw : MonoBehaviour {
    [SerializeField]
    Sprite[] tempphotoframe;
    [SerializeField]
    Transform pealentTransform;
    
    public GameObject[] img;
    GameObject imgInstanceObject;
    //public GameObject SpotManagerGObject;
    // Use this for initialization
    void Start () {
        
        //nearestSpotoDataがnullかを確認する処理を追加
        // tempphotoframe = GameObject.FindGameObjectWithTag("SpotManager").GetComponent<SpotManager>().nearestSpotData.photoFrames;
        GameObject  SpotManagerGObject = GameObject.FindGameObjectWithTag("SpotManager");
        
        if (SpotManagerGObject != null)
        {
            Debug.Log("Test");
            SpotData nearSpotdata = SpotManagerGObject.GetComponent<SpotManager>().nearestSpotData;
            if (nearSpotdata != null) tempphotoframe = nearSpotdata.photoFrames;
            foreach (Sprite frame in tempphotoframe)
            {
                //Imageのプレハブ生成
                imgInstanceObject = Instantiate(img[0],pealentTransform);
                imgInstanceObject.GetComponent<Image>().sprite = frame;
            }
            
        }
        
	}
	
	// Update is called once per frame
	void Update () {
       
    }
    public void Spots()
    {

    }
}
