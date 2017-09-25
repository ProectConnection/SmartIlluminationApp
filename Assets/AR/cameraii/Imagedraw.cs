using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imagedraw : MonoBehaviour {
    Texture2D[] tempphotoframe;
	// Use this for initialization
	void Start () {
        //nearestSpotoDataがnullかを確認する処理を追加
        tempphotoframe = GameObject.FindGameObjectWithTag("SpotManager").GetComponent<SpotManager>().nearestSpotData.photoFrames;
	}
	
	// Update is called once per frame
	void Update () {
       
    }
}
