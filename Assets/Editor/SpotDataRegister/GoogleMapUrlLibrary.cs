using UnityEngine;

public class GoogleMapUrlLibrary{
    static public bool IsGoogleMapUrl(string url)
    {
        return url.IndexOf("https://www.google.co.jp/maps/") >= 0;
    }

    static public bool ExtractRetAndLetByUrl(string url,out double Longitude,out double Letitude)
    {
        bool successful = false;
        //文字列から緯度経度の取り出し
        int coordinateIndex = url.IndexOf("!3d");
        string substr = url.Substring(coordinateIndex + 3, url.Length - (coordinateIndex + 3));
        string substr2 = substr.Substring(substr.IndexOf("!4d") + 3, substr.Length - (substr.IndexOf("!4d") + 3));
        successful = double.TryParse(substr.Substring(0, substr.IndexOf("!4d")), out Letitude);
        successful = successful & double.TryParse(substr2, out Longitude);
        return successful;
    }
}
