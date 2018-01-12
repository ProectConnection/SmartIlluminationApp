using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Runtime.InteropServices;


public class Thumbnails : MonoBehaviour {
    // Use this for initialization

    string Imagename;
    void Start()
    {
        DirectoryInfo dd = new DirectoryInfo(Application.dataPath);
        FileInfo[] info = dd.GetFiles("*.png");
        foreach (FileInfo f in info)
        {
            Debug.Log(f.Name);
        }
    }
    public void OnClick()
    {
 
        
        //WindowsとiOSの撮った写真を左下のウィンドウに表示
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            LoadFile();
            /*try
            {
                byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/" + ("SmartIllumination_" + (nowtime.Year % 100).ToString("00") + nowtime.Month.ToString("00") + nowtime.Day.ToString("00")
                + nowtime.Hour.ToString("00") + nowtime.Minute.ToString("00") + nowtime.Second.ToString("00") + ".png"));
                Texture2D textures = new Texture2D(1, 1);
                textures.filterMode = FilterMode.Trilinear;
                textures.LoadImage(bytes);
                rawImage.texture = textures;
                rawImage.SetNativeSize();
                Debug.Log("OK");
            }
            catch(FormatException)
            {
                byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/" + ("SmartIllumination_" + (nowtime.Year % 100).ToString("00") + nowtime.Month.ToString("00") + nowtime.Day.ToString("00")
                             + nowtime.Hour.ToString("00") + nowtime.Minute.ToString("00") + (nowtime.Second-01).ToString("00") + ".png"));
                Texture2D textures = new Texture2D(1, 1);
                textures.filterMode = FilterMode.Trilinear;
                textures.LoadImage(bytes);
                rawImage.texture = textures;
                rawImage.SetNativeSize();
                Debug.Log("NO");
            }*/
        } 
         //byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/1943[1].jpg");
        
        //Androidの撮った写真を左下のウィンドウに表示
        /*if (Application.platform == RuntimePlatform.Android)
        {
           byte[] bytes = File.ReadAllBytes("/storage/emulated/0/DCIM/SmartIlluminationWalk" + "/" + ("SmartIllumination_" + (nowtime.Year % 100).ToString("00") + nowtime.Month.ToString("00") + nowtime.Day.ToString("00")
             + nowtime.Hour.ToString("00") + nowtime.Minute.ToString("00") + nowtime.Second.ToString("00") + ".png"));
        
        Texture2D textures = new Texture2D(1, 1);
        textures.filterMode = FilterMode.Trilinear;
        textures.LoadImage(bytes);
       
        rawImage.texture = textures;
        rawImage.SetNativeSize();
        }

        //iOSの撮った写真を左下のウィンドウに表示
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
                byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/" + ("SmartIllumination_" + (nowtime.Year % 100).ToString("00") + nowtime.Month.ToString("00") + nowtime.Day.ToString("00")
                + nowtime.Hour.ToString("00") + nowtime.Minute.ToString("00") + nowtime.Second.ToString("00") + ".png"));
                Texture2D textures = new Texture2D(1, 1);
                textures.filterMode = FilterMode.Trilinear;
                textures.LoadImage(bytes);
                rawImage.texture = textures;
                rawImage.SetNativeSize();
         
            

           
        }*/
        RectTransform Rt = GetComponent<RectTransform>();
        Rt.sizeDelta = new Vector2(140, 184);
        //yield return null;
    }
    public void LoadFile()
    {
        RawImage rawImage = GetComponent<RawImage>();
        DateTime nowtime = DateTime.Now;
        Sprite[] image = Resources.LoadAll<Sprite>(Application.persistentDataPath);
        Debug.Log(image);
        Imagename= "SmartIllumination_" + (nowtime.Year % 100).ToString("00") + nowtime.Month.ToString("00") + nowtime.Day.ToString("00")
                                        + nowtime.Hour.ToString("00") + nowtime.Minute.ToString("00") + nowtime.Second.ToString("00") + ".png";
        byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/" + Imagename);
        Debug.Log(bytes);
        //FileInfo files = new FileInfo(Application.dataPath + "/" );
        Texture2D textures = new Texture2D(1, 1);
        textures.filterMode = FilterMode.Trilinear;
        textures.LoadImage(bytes);
        rawImage.texture = textures;
        rawImage.SetNativeSize();
        //Debug.Log(files);
        
    }
    // Update is called once per frame

}
