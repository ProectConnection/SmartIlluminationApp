using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Runtime.InteropServices;


public class Thumbnails : MonoBehaviour {
    public GameObject ButtonCheick;
    string _storageDir ;
    // Use this for initialization
   public void OnClick()
    {
        string DirectoryPass;
        RawImage rawImage = GetComponent<RawImage>();
        DateTime nowtime = DateTime.Now;
        Debug.Log(Application.persistentDataPath + "/" + ("SmartIllumination_" + (nowtime.Year % 100).ToString("00") + nowtime.Month.ToString("00") + nowtime.Day.ToString("00")
            + nowtime.Hour.ToString("00") + nowtime.Minute.ToString("00") + nowtime.Second.ToString("00") + ".png"));
        byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/" + ("SmartIllumination_" + (nowtime.Year % 100).ToString("00") + nowtime.Month.ToString("00") + nowtime.Day.ToString("00")
        + nowtime.Hour.ToString("00") + nowtime.Minute.ToString("00") + nowtime.Second.ToString("00") + ".png")); //"/1943[1].jpg"); 
                                                                                                                  // byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/1943[1].jpg");


        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log(_storageDir + "/DCIM/SmartIlluminationWalk" + "/" + ("SmartIllumination_" + (nowtime.Year % 100).ToString("00") + nowtime.Month.ToString("00") + nowtime.Day.ToString("00")
            + nowtime.Hour.ToString("00") + nowtime.Minute.ToString("00") + nowtime.Second.ToString("00") + ".png"));

            bytes = File.ReadAllBytes( "/DCIM/SmartIlluminationWalk" + "/" + ("SmartIllumination_" + (nowtime.Year % 100).ToString("00") + nowtime.Month.ToString("00") + nowtime.Day.ToString("00")
             + nowtime.Hour.ToString("00") + nowtime.Minute.ToString("00") + nowtime.Second.ToString("00") + ".png"));
        }
        Texture2D textures = new Texture2D(1, 1);
        textures.filterMode = FilterMode.Trilinear;
        textures.LoadImage(bytes);
       
        rawImage.texture = textures;
        rawImage.SetNativeSize();
       
        RectTransform Rt = GetComponent<RectTransform>();
        Rt.sizeDelta = new Vector2(140, 184);
        //yield return null;
    }

    // Update is called once per frame

}
