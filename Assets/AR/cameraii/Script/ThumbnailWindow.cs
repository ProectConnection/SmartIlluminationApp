using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Runtime.InteropServices;

public class ThumbnailWindow : MonoBehaviour
{
    public void OnWindow()
    {
        RawImage rawImage = GetComponent<RawImage>();
        DateTime nowtime = DateTime.Now;
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor )
        {
            byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/" + ("SmartIllumination_" + (nowtime.Year % 100).ToString("00") + nowtime.Month.ToString("00") + nowtime.Day.ToString("00")
            + nowtime.Hour.ToString("00") + nowtime.Minute.ToString("00") + nowtime.Second.ToString("00") + ".png"));

            Texture2D textures = new Texture2D(1, 1);
            textures.filterMode = FilterMode.Trilinear;
            textures.LoadImage(bytes);

            rawImage.texture = textures;
            rawImage.SetNativeSize();
        }
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
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/" + ("SmartIllumination_" + (nowtime.Year % 100).ToString("00") + nowtime.Month.ToString("00") + nowtime.Day.ToString("00")
            + nowtime.Hour.ToString("00") + nowtime.Minute.ToString("00") + nowtime.Second.ToString("00") + ".png"));

            Texture2D textures = new Texture2D(1, 1);
            textures.filterMode = FilterMode.Trilinear;
            textures.LoadImage(bytes);

            rawImage.texture = textures;
            rawImage.SetNativeSize();
        }
        RectTransform Rt = GetComponent<RectTransform>();
        Rt.sizeDelta = new Vector2(1080/1.2f, 1920/1.2f);
        /* Vector2 pos = GetComponent<RectTransform>().anchoredPosition;
         pos.x = 537;
         pos.y = 950;
         GetComponent<RectTransform>().anchoredPosition = pos;*/
    }
  
}
