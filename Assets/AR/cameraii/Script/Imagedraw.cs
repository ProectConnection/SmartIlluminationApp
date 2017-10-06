using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Imagedraw : MonoBehaviour {
    
    [SerializeField]
    Transform pealentTransform;
    
    public GameObject img;
    List<GameObject> imgInstanceObject;
   
    
    //public GameObject SpotManagerGObject;
    // Use this for initialization
    void Start () {
        imgInstanceObject = new List<GameObject>();
        //nearestSpotoDataがnullかを確認する処理
        
        GameObject  SpotManagerGObject = GameObject.FindGameObjectWithTag("SpotManager");

        if (SpotManagerGObject != null)
        {
            
            SpotData nearSpotdata = SpotManagerGObject.GetComponent<SpotManager>().nearestSpotData;
            if (nearSpotdata != null)GeneratePhotoFrame(nearSpotdata.photoFrames);  
        }
        
	}

    public void GeneratePhotoFrame(Sprite[] tempphotoframe)
    {
        int i = 0;
        foreach (GameObject tt in imgInstanceObject) {
            Destroy(tt);
        }
        imgInstanceObject.Clear();
         foreach (Sprite frame in tempphotoframe)
        {
            //Imageのプレハブ生成
            imgInstanceObject.Add(Instantiate(img, pealentTransform));
            imgInstanceObject[i].GetComponent<Image>().sprite = frame;
            i++;
        }

    }
}
