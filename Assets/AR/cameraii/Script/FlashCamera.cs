using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class FlashCamera : MonoBehaviour {
    Image ClickButtonImg;
    Text ClickButtonText;
    [SerializeField]
    Button inCameraButton;
    // Use this for initialization
#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	//private static extern void _WriteImageToCamera(captureDevice);
	private static extern void _WriteImageToCamera(string path,string CalledGameObjectName,string CalledMethodName);
#endif
    private void Start()
    {
        inCameraButton.onClick.AddListener(ToggleButtonActive);
        ClickButtonImg = GetComponent<Image>();
        ClickButtonText = transform.GetChild(0).GetComponent<Text>();
    }

    public void ToggleFlash(){
        Debug.Log("Call Toggle Flash");
        #if UNITY_IOS && !UNITY_EDITOR
		        _WriteImageToCamera(null,this.gameObject.name,null);
        #endif
        
	}

    public void ToggleButtonActive()
    {
        ClickButtonImg.enabled = !ClickButtonImg.enabled;
        ClickButtonText.enabled = !ClickButtonText.enabled;
    }

	

}
