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
        Debug.Log("_storageDir" + _storageDir);
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
        // Application.CaptureScreenshot("../../../../DCIM/Camera/" + fileName);
        //Application.CaptureScreenshot("phone/DCIM/Camera/" + fileName);
        DateTime nowtime = DateTime.Now;
        string fileName = "SmartIllumination_" +(nowtime.Year % 100).ToString("00") + nowtime.Month.ToString("00") + nowtime.Day.ToString("00")
            + nowtime.Hour.ToString("00")  + nowtime.Minute.ToString("00") +  nowtime.Second.ToString("00") + ".png";
        switch (Application.platform) {
            case (RuntimePlatform.Android)://内部ストレージへの保存完了（他機種でのテスト必須）
            DirectoryPass = _storageDir + "/DCIM/SmartIlluminationWalk";
            if (!Directory.Exists(DirectoryPass)) Directory.CreateDirectory(DirectoryPass);
            File.WriteAllBytes(DirectoryPass + "/" +fileName, bytes);//写真が保存されない
                break;
            case (RuntimePlatform.IPhonePlayer):
                //NO
                break;
            case (RuntimePlatform.WindowsPlayer):
            File.WriteAllBytes(Application.temporaryCachePath + "/" + fileName, bytes);//写真は保存されるが意図した場所に保存されない
                break;
        }
        //Debug.Log("" + Application.platform);
    }



    // Update is called once per frame
    void Update () {
		
	}
}
