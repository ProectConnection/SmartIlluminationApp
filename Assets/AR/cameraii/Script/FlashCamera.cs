using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class FlashCamera : MonoBehaviour {

	// Use this for initialization
#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	//private static extern void _WriteImageToCamera(captureDevice);
	private static extern void _WriteImageToCamera(string path,string CalledGameObjectName,string CalledMethodName);
#endif
	public void ToggleFlash(){
		#if UNITY_IOS && !UNITY_EDITOR
		_WriteImageToCamera(null,this.gameObject.name,null);
		#endif
	}

	

}
