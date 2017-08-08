using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class GoogleMapDrawer : MonoBehaviour {
    float initLatitude = 40.713728f;
    float initLongitude = -73.998672f;
    public string key = null;
    
    LocationCoordination calculator;

    string Url = @"https://maps.googleapis.com/maps/api/staticmap?size=500x500&maptype=terrain&center=40.714728,-73.998672&zoom=17&sensor=false";


    // Use this for initialization
    void Start () {
		if(calculator == null)
        {
            //検索用のLocationCoordinationの参照を
            //渡す
            calculator = GameObject.FindGameObjectWithTag("Locator").GetComponent<Locator>().locationCoordination;
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
        Url = string.Format(@"https://maps.googleapis.com/maps/api/staticmap?size=500x500&maptype=terrain&center={0},{1}&zoom=17&scale=2language=jp&style=element:labels|visibility:off&sensor=false", calculator.GetLatitude, calculator.GetLongitude);
        if(key != null && key.Length != 0)
        {
            Url += "&key=" + key;
        }
        Url = System.Uri.EscapeUriString(Url);
        StartCoroutine(DownloadFromUrl(this.Url, texture2d => UpdateSprite(texture2d)));
    }

    IEnumerator DownloadFromUrl(string url,Action<Texture2D> texture2d)
    {
        var www = new WWW(url);
        yield return www;

        texture2d(www.texture);
    }

    public void UpdateSprite(Texture2D tex)
    {
        GetComponent<Renderer>().material.mainTexture = tex;
    }
}
