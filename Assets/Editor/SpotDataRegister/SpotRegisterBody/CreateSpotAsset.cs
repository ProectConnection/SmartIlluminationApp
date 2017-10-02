using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateSpotAsset
{

    public static void GenerateSpotData(string url, string spotName, string parentPass,string savePass,StampID stampId,Sprite[] photoFrames)
    {
        bool isGoogleMapUrl = url.IndexOf("https://www.google.co.jp/maps/") >= 0;
        try
        {
            if (!isGoogleMapUrl) throw new InVaildGoogleMapURL();

            bool successful = false;
            float tLong;
            float tLet;

            //文字列から緯度経度の取り出し
            int coordinateIndex = url.IndexOf("/@");
            string substr = url.Substring(coordinateIndex + 2, url.Length - (coordinateIndex + 2));
            string substr2 = substr.Substring(substr.IndexOf(",") + 1, substr.Length - (substr.IndexOf(",") + 1));
            successful = float.TryParse(substr.Substring(0, substr.IndexOf(',')), out tLet);
            successful = successful & float.TryParse(substr2.Substring(0, substr2.IndexOf(',')), out tLong);

            if (!successful) throw new FailedConvateCoordination();
            
            //フォルダが存在しない場合、フォルダを新規作成する
            string[] subpasses = AssetDatabase.GetSubFolders(parentPass);
            bool IsFolderExist = false;
            foreach(string subpass in subpasses)
            {
                if (subpass == parentPass + "/" + savePass)
                {
                    IsFolderExist = true;
                    break;
                }
            }
            if (!IsFolderExist)
            {
                Debug.Log("save passに指定されたフォルダがありません！\nsave passに指定されたフォルダを新規作成します。");
                AssetDatabase.CreateFolder(parentPass, savePass);
            }

            //データの格納と作成
            SpotData newAsset = ScriptableObject.CreateInstance<SpotData>();
            newAsset.SetNewDatas(spotName, tLong, tLet, stampId, photoFrames);
            string pass = AssetDatabase.GenerateUniqueAssetPath(parentPass + "/" + savePass + "/" + spotName + ".asset");
            AssetDatabase.CreateAsset(newAsset, pass);
            Debug.Log("Generate SpotData!\n" + "Saved To = " + pass);
        }

        catch (FailedConvateCoordination)
        {
            Debug.LogError("緯度経度の変換に失敗しました。\n" + "URLが完全に入力されているか確認してください。");
        }
        catch (InVaildGoogleMapURL)
        {
            Debug.LogError("URLがGoogle Map形式のURLではありません。");
        }
    }
    public static void GenerateSpotData(SpotRegisterData registerDatas)
    {
        bool isGoogleMapUrl = GoogleMapUrlLibrary.IsGoogleMapUrl(registerDatas.spotUrl);
        try
        {
            if (!isGoogleMapUrl) throw new InVaildGoogleMapURL();

            bool successful = false;
            double tLong;
            double tLet;

            successful = GoogleMapUrlLibrary.ExtractRetAndLetByUrl(registerDatas.spotUrl,out tLong,out tLet);

            if (!successful) throw new FailedConvateCoordination();

            //フォルダが存在しない場合、フォルダを新規作成する
            string[] subpasses = AssetDatabase.GetSubFolders(registerDatas.ParentSavePass);
            bool IsFolderExist = false;
            foreach (string subpass in subpasses)
            {
                if (subpass == registerDatas.ParentSavePass + "/" + registerDatas.savePass)
                {
                    IsFolderExist = true;
                    break;
                }
            }
            if (!IsFolderExist)
            {
                Debug.Log("save passに指定されたフォルダがありません！\nsave passに指定されたフォルダを新規作成します。");
                AssetDatabase.CreateFolder(registerDatas.ParentSavePass, registerDatas.savePass);
            }

            //データの格納と作成
            SpotData newAsset = ScriptableObject.CreateInstance<SpotData>();
            newAsset.SetNewDatas(registerDatas, tLong, tLet);
            string pass = AssetDatabase.GenerateUniqueAssetPath(registerDatas.ParentSavePass + "/" + registerDatas.savePass+ "/" + registerDatas.fileName + ".asset");
            AssetDatabase.CreateAsset(newAsset, pass);
            Debug.Log("Generate SpotData!\n" + "Saved To = " + pass);
        }

        catch (FailedConvateCoordination)
        {
            Debug.LogError("緯度経度の変換に失敗しました。\n" + "URLが完全に入力されているか確認してください。");
        }
        catch (InVaildGoogleMapURL)
        {
            Debug.LogError("URLがGoogle Map形式のURLではありません。");
        }
    }
}
