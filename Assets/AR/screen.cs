using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;


public class screen : MonoBehaviour {
#if !UNITY_EDITOR && UNITY_ANDROID
    AndroidJavaClass env;
#endif


    public Camera ArCam;
    string _storageDir;
    // Use this for initialization

    void Start()
    {
    #if !UNITY_EDITOR && UNITY_ANDROID
        env = new AndroidJavaClass("android.os.Environment");
        AndroidJavaObject storageDir = env.CallStatic<AndroidJavaObject>("getExternalStorageDirectory");
        _storageDir = storageDir.Call<string>("getCanonicalPath");
    #endif
    }

    public void CaptchaScreen()
    {
        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        RenderTexture rt = new RenderTexture(screenShot.width, screenShot.height, 24);
        RenderTexture prev = ArCam.targetTexture;
        ArCam.targetTexture = rt;
        ArCam.Render();
        ArCam.targetTexture = prev;
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, screenShot.width, screenShot.height), 0, 0);
        screenShot.Apply();
        

        byte[] bytes = screenShot.EncodeToPNG();
        UnityEngine.Object.Destroy(screenShot);
        string DirectoryPass;
        string fileName = "SmartIllumination_" + System.DateTime.Now.Hour.ToString()  +"" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + ".png";
        // Application.CaptureScreenshot("../../../../DCIM/Camera/" + fileName);
        //Application.CaptureScreenshot("phone/DCIM/Camera/" + fileName);
        if (Application.platform == RuntimePlatform.Android)
        {
            DirectoryPass = _storageDir + "/DCIM/SmartIlluminationWalk";
            // File.WriteAllBytes(Environment.GetEnvironmentVariable("/"),bytes);
            //File.WriteAllBytes("../../../../DCIM/Camera/" + fileName, bytes);//写真が保存されない

            if (!Directory.Exists(DirectoryPass)) Directory.CreateDirectory(fileName);
            File.WriteAllBytes(DirectoryPass + "/" +fileName, bytes);//写真が保存されない
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            //NO
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            File.WriteAllBytes(Application.temporaryCachePath + "/" + fileName, bytes);//写真は保存されるが意図した場所に保存されない
        }
         Debug.Log(""+ Application.temporaryCachePath);
        //Debug.Log("" + Application.platform);
    }



    // Update is called once per frame
    void Update () {
		
	}
}
