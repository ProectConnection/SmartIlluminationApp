using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {
	public int Width = 1920;
	public int Height = 1080;
	public int FPS = 30;
	
	void Start () {
		WebCamDevice[] devices = WebCamTexture.devices;
		// display all cameras
		//カメラ検索
		for (var i = 0; i < devices.Length; i++) {
			Debug.Log (devices [i].name);
		}

		//デバイス名,映し出す幅,映し出す高さ,FPS値
		WebCamTexture webcamTexture = new WebCamTexture(devices[0].name, Width, Height, FPS);

		//オブジェクトのマテリアルを貼り付け
		GetComponent<Renderer> ().material.mainTexture = webcamTexture;

		//実行
		webcamTexture.Play();
	}
}