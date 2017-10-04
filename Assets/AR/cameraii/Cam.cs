using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Cam : MonoBehaviour {
	public int Width = 1920;
	public int Height = 1080;
	public int FPS = 30;
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
        //text = this.GetComponent<Text>();
    }
    
    public  void OCamFlg() {
        //アウトカム
        WebCamDevice[] devices = WebCamTexture.devices;
        WebCamTexture webcamTexture = new WebCamTexture(devices[0].name, Width, Height, FPS);//0で外カメラ、1でインカメラ;
        //デバイス名,映し出す幅,映し出す高さ,FPS値
        if (incamera.incamflg == false) {
            //text.text = "No";
            webcamTexture = new WebCamTexture(devices[0].name, Width, Height, FPS);//0で外カメラ、1でインカメラ
            
        }
        else if (incamera.incamflg == true)
        {
            //text.text ="ok";
            webcamTexture = new WebCamTexture(devices[1].name, Width, Height, FPS);//0で外カメラ、1でインカメラ
        }

                                                                                          
        GetComponent<Renderer>().material.mainTexture = webcamTexture;   //オブジェクトのマテリアルを貼り付け

        //実行
        webcamTexture.Play();
        Debug.Log("camera" + incamera.incamflg);
        
    }
  /* public  void ICamFlg() { 
        //インカム
        
            WebCamTexture webcamTexture = new WebCamTexture(devices[1].name, Width, Height, FPS);//0で外カメラ、1でインカメラ
            Debug.Log("camera" + incamera.incamflg);
            //オブジェクトのマテリアルを貼り付け
            GetComponent<Renderer>().material.mainTexture = webcamTexture;

            //実行
            webcamTexture.Play();
        }*/
   }

    