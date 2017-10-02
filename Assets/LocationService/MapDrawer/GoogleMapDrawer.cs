using System.Collections;
using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class GoogleMapDrawer : MonoBehaviour {
    float initLatitude = 40.713728f;
    float initLongitude = -73.998672f;
    public string key = null;
    [SerializeField]
    string signeture = null;
    int MapSize = 17;
    public int mapSize
    {
        get
        {
            return MapSize;
        }
        set
        {
            //Google Static Map APIで指定できるサイズでない場合の例外処理
            if(value < 0)
            {
                MapSize = 0;
            }
            else if(value > 23)
            {
                MapSize = 23;
            }
            else
            {
                MapSize = value;
            }
        }
    }
    [SerializeField]
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
            calculator = GameObject.FindGameObjectWithTag("Locator").GetComponent<Locator>().locationCoordination;
            GameObject.FindGameObjectWithTag("Locator").GetComponent<Locator>().OnLocationUpdate.AddListener(BuildMap);
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
        Url = string.Format(@"https://maps.googleapis.com/maps/api/staticmap?size=500x500&maptype=terrain&center={0},{1}&zoom={2}&scale={3}language=jp&style=element:labels|visibility:off&sensor=false", calculator.GetLatitude, calculator.GetLongitude,mapSize,mapScale);
        if(key != null && key.Length != 0)
        {
            Url += "&key=" + key;
        }
        if(signeture != null && signeture.Length != 0)
        {
            Url += "&signature=" + signeture;
        }
        Url = System.Uri.EscapeUriString(Url);
        StartCoroutine(DownloadFromUrl(this.Url, texture2d => UpdateSprite(texture2d)));
    }

    IEnumerator DownloadFromUrl(string url,Action<Texture2D> texture2d)
    {
        var www = new WWW(url);
        yield return www;
        //取得ミスで稀に403エラーが発生、エラー処理が必要
        texture2d(www.texture);
    }

    public void UpdateSprite(Texture2D tex)
    {
        GetComponent<Renderer>().material.mainTexture = tex;
    }
}
