using UnityEngine;

public class GoogleMapUrlLibrary{
    static public bool IsGoogleMapUrl(string url)
    {
        return url.IndexOf("https://www.google.co.jp/maps/") >= 0;
    }

    static public bool ExtractRetAndLetByUrl(string url,out float Longitude,out float Letitude)
    {
        bool successful = false;
        //文字列から緯度経度の取り出し
        int coordinateIndex = url.IndexOf("/@");
        string substr = url.Substring(coordinateIndex + 2, url.Length - (coordinateIndex + 2));
        string substr2 = substr.Substring(substr.IndexOf(",") + 1, substr.Length - (substr.IndexOf(",") + 1));
        successful = float.TryParse(substr.Substring(0, substr.IndexOf(',')), out Letitude);
        successful = successful & float.TryParse(substr2.Substring(0, substr2.IndexOf(',')), out Longitude);
        return successful;
    }
}
