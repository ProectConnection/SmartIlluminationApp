using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Cam : MonoBehaviour {
	public int Width = 1920;
	public int Height = 1080;
	public int FPS = 30;
	RawImage Raw;

    //public Text  text;
    //WebCamTexture webcamTexture = new WebCamTexture(devices[0].name, Width, Height, FPS);//0で外カメラ、1でインカメラ
    void Start() {
		
        // display all cameras
        //WebCamTexture webcamTexture= new WebCamTexture(devices[0].name, Width, Height, FPS); ;
        //カメラ検索
       /* for (var i = 0; i < devices.Length; i++) {
            Debug.Log(devices[i].name);
        }*/
            OCamFlg();

			transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);

        //text = this.GetComponent<Text>();
    }
    
    public  void OCamFlg() {
        //アウトカム
        WebCamDevice[] devices = WebCamTexture.devices;
        int i = 0;
	
        WebCamTexture webcamTexture = new WebCamTexture(devices[0].name, Width, Height, FPS);//0で外カメラ、1でインカメラ;
	                                                                          //デバイス名,映し出す幅,映し出す高さ,FPS値
		switch(Application.platform){

		case (RuntimePlatform.IPhonePlayer):
			this.transform.localScale = new Vector3 (-transform.localScale.x, -transform.localScale.y, -transform.localScale.z); 
			break;
		}
		if (incamera.incamflg == true)
        {
            for (i = 0; i < devices.Length; i++)
            {
                webcamTexture = new WebCamTexture(devices[1].name, Width, Height, FPS);//0で外カメラ、1でインカメラ
                Debug.Log(i);
            }
        }
        else
        {
            i = 0;
        }
        GetComponent<Renderer>().material.mainTexture = webcamTexture;   //オブジェクトのマテリアルを貼り付け
                                                                         //実行
        webcamTexture.Play();
        Debug.Log("camera" + incamera.incamflg);
    }
}