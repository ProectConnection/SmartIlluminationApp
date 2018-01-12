using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using System.Runtime.InteropServices;


public class screen : MonoBehaviour {
	public UnityEventQueueSystem OnCompleteCapture;
	public UnityEventQueueSystem OnFailCapture;
    public GameObject ThumbButton;
    public bool ThunbButtonflg;

#if !UNITY_EDITOR && UNITY_ANDROID
    AndroidJavaClass env;
#endif

    [SerializeField]
    AudioClip ShutterSound;
    AudioSource ShutterSEObject;

    Camera ArCam;
    string _storageDir;
	string fileName;
    // Use this for initialization
	#if !UNITY_EDITOR && UNITY_IOS
	[DllImport("__Internal")]
	private static extern void _PlaySystemShutterSound();
	[DllImport("__Internal")]
	private static extern void _WriteImageToAlbum(string path,string CalledGameObjectName,string CalledMethodName);

	#endif
    void Start()
    {
        ThumbButton.SetActive(false);
        ThunbButtonflg = false;
#if !UNITY_EDITOR && UNITY_ANDROID
        env = new AndroidJavaClass("android.os.Environment");
        AndroidJavaObject storageDir = env.CallStatic<AndroidJavaObject>("getExternalStorageDirectory");
        _storageDir = storageDir.Call<string>("getCanonicalPath");
        Debug.Log("_storageDir" + _storageDir);
#endif

        ShutterSEObject = new GameObject("ShutterSEObject").AddComponent<AudioSource>();
        ShutterSEObject.clip = ShutterSound;
        ArCam = Camera.main;
    }

	IEnumerator WaitUntilFinishedWriting(Action callback){
		while (!File.Exists (TemporaryScreenShotPath())) {
			yield return null;
		}
		callback ();
		yield break;
	}

	string TemporaryScreenShotPath(){
		return Application.persistentDataPath + "/" + fileName;
	}

	public void DidImageWriteToAlbum(string errorDescription){
		if (string.IsNullOrEmpty (errorDescription)) {
			Debug.Log (">>>>> Image have been Written To Album Successfully.");
			Debug.Log (">>>>> Delete Temporary Screenshot.");
			File.Delete (TemporaryScreenShotPath ());
		} else {
			Debug.Log (">>>>> An Error Occured. Error Description is..." + errorDescription);
		}
	}

    public void CaptchaScreen()
    {
#if !UNITY_EDITOR && UNITY_IOS
        _PlaySystemShutterSound ();
#else
        ShutterSEObject.Play();
#endif

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
        string DirectoryPass = "";
        DateTime nowtime = DateTime.Now;
        fileName = "SmartIllumination_" +(nowtime.Year % 100).ToString("00") + nowtime.Month.ToString("00") + nowtime.Day.ToString("00")
            + nowtime.Hour.ToString("00")  + nowtime.Minute.ToString("00") +  nowtime.Second.ToString("00") + ".png";
		
		//directorypassの成型
        switch (Application.platform) {

            case (RuntimePlatform.Android)://内部ストレージへの保存完了（他機種でのテスト必須）
            DirectoryPass = _storageDir + "/DCIM/SmartIlluminationWalk";
               
            if (!Directory.Exists(DirectoryPass)) Directory.CreateDirectory(DirectoryPass);
                break;
		case (RuntimePlatform.IPhonePlayer):
			DirectoryPass = Application.persistentDataPath;
			break;

            case (RuntimePlatform.WindowsPlayer):
            case (RuntimePlatform.WindowsEditor)://データパスへの保存(C:/user/ユーザー名/appdata/LocalLow)
                DirectoryPass = Application.persistentDataPath;
                Debug.Log(DirectoryPass);
                break;
        }
        File.WriteAllBytes(DirectoryPass + "/" + fileName, bytes);
		//iOSの時のみ撮影処理が特殊なので例外的な処理を行う

#if !UNITY_EDITOR && UNITY_IOS
			
			StartCoroutine (WaitUntilFinishedWriting (() => {
				_WriteImageToAlbum (TemporaryScreenShotPath (),gameObject.name,((Action<string>)DidImageWriteToAlbum).Method.Name);
			}));
#endif
    }



    // Update is called once per frame
    void Update () {
		
	}
    public void OnThum()
    {
        if (ThunbButtonflg == false)
        {
            ThumbButton.SetActive(true);
            ThunbButtonflg = true;
        }
    }
}
