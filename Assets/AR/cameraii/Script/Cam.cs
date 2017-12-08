using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Cam : MonoBehaviour
{
    public int Width = 1920;
    public int Height = 1080;
    public int FPS = 30;
    RawImage Raw;
    Vector3 WhenStartTransformScale;
    public static bool CameraFlg;
    Renderer thisRenderer;
    WebCamTexture webcamTexture;

    bool flgs;
    //public Text  text;
    //WebCamTexture webcamTexture = new WebCamTexture(devices[0].name, Width, Height, FPS);//0で外カメラ、1でインカメラ
    void Start()
    {
        thisRenderer = GetComponent<Renderer>();
        WhenStartTransformScale = transform.localScale;
        // WebCamDevice[] devices = WebCamTexture.devices;
        // display all cameras
        //WebCamTexture webcamTexture= new WebCamTexture(devices[0].name, Width, Height, FPS); ;
        //カメラ検索
        /* for (var i = 0; i < devices.Length; i++) {
             Debug.Log(devices[i].name);
         }*/
        CameraFlg = false;
        flgs = CameraFlg;

        transform.localScale = new Vector3(WhenStartTransformScale.x, WhenStartTransformScale.y, WhenStartTransformScale.z);
        //WebCamTexture webcamTexture = new WebCamTexture(devices[0].name, Width, Height, FPS);//0で外カメラ、1でインカメラ;
        OCamFlg();



        //text = this.GetComponent<Text>();
    }
    void Update()
    {
        //transform.localScale = new Vector3(WhenStartTransformScale.x, WhenStartTransformScale.y, WhenStartTransformScale.z);
        //WebCamDevice[] devices = WebCamTexture.devices;
        if (flgs != CameraFlg)
        {
            OCamFlg();
        }
        flgs = CameraFlg;
    }

    public void OCamFlg()
    {
        //アウトカム
        WebCamDevice[] devices = WebCamTexture.devices;
        int i = 0;
        Debug.Log(devices.Length);
        Debug.Log(devices[0].name);
        bool aaa = devices[i].isFrontFacing;
        Debug.Log(name + "isFrontFacing=" + aaa);
        // Debug.Log(devices[1].name);
        //WebCamTexture webcamTexture = new WebCamTexture(devices[0].name, Width, Height, FPS);//0で外カメラ、1でインカメラ;
        //デバイス名,映し出す幅,映し出す高さ,FPS値
        if (webcamTexture != null)
        {
            webcamTexture.Stop();
        }
        switch (Application.platform)
        {

            case (RuntimePlatform.IPhonePlayer):
                transform.localScale = new Vector3(WhenStartTransformScale.x, -WhenStartTransformScale.y, WhenStartTransformScale.z);
                break;
        }
        if (CameraFlg == false)
        {
            webcamTexture = new WebCamTexture(devices[0].name, Width, Height, FPS);//0で外カメラ、1でインカメラ;
            thisRenderer.material.mainTexture = webcamTexture;   //オブジェクトのマテリアルを貼り付け
                                                                 //実行
            webcamTexture.Play();
        }
        else
        {

            //for (i = 0; i < devices.Length; i++)
            //{
            webcamTexture = new WebCamTexture(devices[1].name, Width, Height, FPS);//0で外カメラ、1でインカメラ;
            thisRenderer.material.mainTexture = webcamTexture;   //オブジェクトのマテリアルを貼り付け
                                                                 //実行
//<<<<<<< HEAD
                                                                 //transform.rotation = Quaternion.Euler(0, 0, 180);
            if (Application.platform == RuntimePlatform.Android)//Androidのインカメラ補正
            {
                transform.localScale = new Vector3(-WhenStartTransformScale.x, WhenStartTransformScale.y, WhenStartTransformScale.z);
            }
            if (Application.platform == RuntimePlatform.IPhonePlayer)//iOSのインカメラ補正
            {
                transform.localScale = new Vector3(WhenStartTransformScale.x, WhenStartTransformScale.y, WhenStartTransformScale.z);
            }
                Debug.Log(transform.rotation);
//=======
            //transform.rotation = Quaternion.Euler(0, 0, 180);
            if(Application.platform==RuntimePlatform.Android){
            transform.localScale = new Vector3(-WhenStartTransformScale.x, WhenStartTransformScale.y, WhenStartTransformScale.z);
            }
            if(Application.platform==RuntimePlatform.IPhonePlayer){
                            transform.localScale = new Vector3(WhenStartTransformScale.x, WhenStartTransformScale.y, WhenStartTransformScale.z);
            }
            Debug.Log(transform.rotation);
//>>>>>>> f166e5fcfa6177a21acef291e146ae1925966252
            webcamTexture.Play();
            //}
        }
        /*else
        {
            i = 0;
        }
        GetComponent<Renderer>().material.mainTexture = webcamTexture;   //オブジェクトのマテリアルを貼り付け
                                                                         //実行
        webcamTexture.Play();
*/
    }
    
    private void OnDestroy()
    {
        webcamTexture.Stop();
    }

class Foo {
  [DllImport ("__Internal")]
  private static extern float FooPluginFunction();

}

}