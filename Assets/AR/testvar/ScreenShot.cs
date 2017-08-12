using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour {
    public void Shot()
    {
        string format = "yyyy-MM-dd-HH-mm-ss";
        string fileName = System.DateTime.Now.ToString(format) + ".png";
        Application.CaptureScreenshot(fileName);
        string filePath = "";

        switch (Application.platform)
        {
            case RuntimePlatform.IPhonePlayer:
                filePath = Application.persistentDataPath + "/" + fileName;
                break;
            case RuntimePlatform.Android:
                filePath = Application.persistentDataPath + "/" + fileName;
                break;
            default:
                filePath = fileName;
                break;
        }
    //    StartCoroutine(ImageCheck(filePath));
    }
   /* IEnumerator ImageCheck(string _filePath)
    {
        while (File.Exists(_filePath) == false)
        {
            yield return new WaitForSeconds(0.2f);
        }
        Debug.Log("OK");
    }*/
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
