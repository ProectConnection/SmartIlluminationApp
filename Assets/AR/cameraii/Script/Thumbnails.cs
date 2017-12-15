using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Runtime.InteropServices;


public class Thumbnails : MonoBehaviour {
    // Use this for initialization
   public void OnClick()
    {
  
        RawImage rawImage = GetComponent<RawImage>();
        DateTime nowtime = DateTime.Now;

        //WindowsとiOSの撮った写真を左下のウィンドウに表示
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor|| Application.platform == RuntimePlatform.IPhonePlayer)
        {
            byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/" + ("SmartIllumination_" + (nowtime.Year % 100).ToString("00") + nowtime.Month.ToString("00") + nowtime.Day.ToString("00")
            + nowtime.Hour.ToString("00") + nowtime.Minute.ToString("00") + nowtime.Second.ToString("00") + ".png"));

            Texture2D textures = new Texture2D(1, 1);
            textures.filterMode = FilterMode.Trilinear;
            textures.LoadImage(bytes);

            rawImage.texture = textures;
            rawImage.SetNativeSize();
        } 
         //byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/1943[1].jpg");
        
        //Androidの撮った写真を左下のウィンドウに表示
        if (Application.platform == RuntimePlatform.Android)
        {
           byte[] bytes = File.ReadAllBytes("/storage/emulated/0/DCIM/SmartIlluminationWalk" + "/" + ("SmartIllumination_" + (nowtime.Year % 100).ToString("00") + nowtime.Month.ToString("00") + nowtime.Day.ToString("00")
             + nowtime.Hour.ToString("00") + nowtime.Minute.ToString("00") + nowtime.Second.ToString("00") + ".png"));
        
        Texture2D textures = new Texture2D(1, 1);
        textures.filterMode = FilterMode.Trilinear;
        textures.LoadImage(bytes);
       
        rawImage.texture = textures;
        rawImage.SetNativeSize();
        }
        RectTransform Rt = GetComponent<RectTransform>();
        Rt.sizeDelta = new Vector2(140, 184);
        //yield return null;
    }
    
    // Update is called once per frame

}
