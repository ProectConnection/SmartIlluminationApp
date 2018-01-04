using System.Collections;
using UnityEngine;
using System.IO;


[RequireComponent(typeof(Renderer))]
public class GoogleMapDrawer : MonoBehaviour {
    public const string GoogleMapTexFolder = "MapTexture";
    string GoogleMapDirectory;
    [SerializeField]
    float initLatitude = 40.713728f;
    [SerializeField]
    float initLongitude = -73.998672f;
    [SerializeField]
    bool isTrackUser;
    public string key = null;
    [SerializeField]
    string signeture = null;
    
    [SerializeField]
    GameObject ref_LoadingText;
    bool IsGetMapError = true;
    Texture2D ScriptableTexture;
    [SerializeField]
    Texture2D FirstTexture;
    Material thisMaterial;

     [SerializeField]
    float MapSize=17;
    public float mapSize
    {
        get
        {
            return MapSize;
        }
        set
        {
            //Google Static Map APIで指定できるサイズでない場合の例外処理
            if (value < 0)
            {
                MapSize = 0;
            }
            else if (value > 21)
            {
                MapSize = 21;
            }
            else
            {
                MapSize = value;
            }
        }
    }
    public Plane TransformPlane;

    int MapScale = 2;
    public int mapScale
    {
        get
        {
            return MapScale;
        }
        set
        {
            if (value < 1)
            {
                MapScale = 1;
            }
            else if(value > 2)
            {
                MapScale = 2;
            }
            else
            {
                MapScale = value;
            }
        }
    }

    LocationCoordination calculator;

    string Url = @"https://maps.googleapis.com/maps/api/staticmap?size=100x100&maptype=terrain&center=40.714728,-73.998672&zoom=17&sensor=false";


    // Use this for initialization
    void Start () {
		if(calculator == null)
        {

            //検索用のLocationCoordinationの参照を
            //渡す
            //calculator = GameObject.FindGameObjectWithTag("Locator").GetComponent<Locator>().locationCoordination;
            calculator = new LocationCoordination(initLongitude,initLatitude);
            //GameObject.FindGameObjectWithTag("Locator").GetComponent<Locator>().OnLocationUpdate.AddListener(BuildMap);
             thisMaterial = GetComponent<Renderer>().material;
            ScriptableTexture = Instantiate(FirstTexture);
            thisMaterial.mainTexture = ScriptableTexture;
            GoogleMapDirectory = Application.temporaryCachePath + "/" + GoogleMapTexFolder;
            BuildMap();
        }
	}
	
    public LocationCoordination Calculator
    {
        get
        {
            return calculator;
        }
        set
        {
            calculator = value;
            BuildMap();
        }
    }


    public void BuildMap()
    {
        Texture2D mapTexture = new Texture2D(512,512);
        string GoogleMapTexPath = GetMapDatapath();
        if (File.Exists(GoogleMapTexPath))
        {
            GetMapNativeTexture(ref mapTexture);
            thisMaterial.SetTexture("_MainTex", mapTexture);
        }
        else
        {

            Url = string.Format(@"https://maps.googleapis.com/maps/api/staticmap?size=512x512&maptype=terrain&center={0},{1}&zoom={2}&scale={3}language=jp&style=element", calculator.GetLatitude, calculator.GetLongitude, mapSize, mapScale);
            if (key != null && key.Length != 0)
            {
                Url += "&key=" + key;
            }
            if (signeture != null && signeture.Length != 0)
            {
                Url += "&signature=" + signeture;
            }
            Url = System.Uri.EscapeUriString(Url);
            StartCoroutine(DownloadFromUrl(this.Url, (Texture2D)thisMaterial.mainTexture));
        }
    }

    string GetMapDatapath()
    {
        if(!Directory.Exists(GoogleMapDirectory))
        {
            Directory.CreateDirectory(GoogleMapDirectory);
        }
        return GoogleMapDirectory + "/" + "MapTex" + calculator.GetLatitude + "," + calculator.GetLongitude + "," + mapSize + ".png";
    }

    bool GetMapNativeTexture(ref Texture2D textureref)
    {
        textureref.LoadImage(File.ReadAllBytes(GetMapDatapath()), false);
        
        return true;
    }

    bool WriteMapNativeTexture(Texture2D fileTex)
    {
        File.WriteAllBytes(GetMapDatapath(), fileTex.EncodeToPNG());
        return true;
    }

    IEnumerator DownloadFromUrl(string url,Texture2D texture2d)
    {
        var www = new WWW(url);
        yield return www;
        //取得ミスで稀に403エラーが発生、エラー処理が必要
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError(www.error);
        }
        else {
            
            www.LoadImageIntoTexture(ScriptableTexture);
            WriteMapNativeTexture(ScriptableTexture);
            if (ref_LoadingText) ref_LoadingText.SetActive(false);
        }

    }

    //private void OnDestroy()
    public void UpdateSprite(Texture2D tex)
    {
        DestroyImmediate(ScriptableTexture);
        GetComponent<Renderer>().material.mainTexture = tex;
    }

    public void SetLocationCoordinate()
    {
         
    }
}
