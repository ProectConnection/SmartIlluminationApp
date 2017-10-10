using UnityEngine;
using System.Collections;
using System.IO;
using System;

/*
 名前:ScreenShotScript
 作成者:yuutaro otsuka(yuutarousoft)
 
    変数
    [serializeField]KeyCode screenShotKey   スクリーンショットを撮影する為に押すキー
    string currentScreenShotDirectory       スクリーンショットを保存するフォルダ
    string filename                         スクリーンショットのファイル名
                                            （現在日時時刻）.pngで保存
    [serializeField]int ResolutionRate      保存するスクリーンショットの解像度の倍率(1x-10x)
                                            スクリーン解像度 * ResolutionRateで保存される
    関数
    -void Awake()
    保存フォルダの指定、フォルダが無い場合は作成する
    -void Update()
    スクリーンショットキーの入力判定
    押された時に、CaptureScreen()を呼び出す
    -IEnumlator CaptureScreen()
    ファイル名を生成、スクリーンショットを保存する
     */
     //変更する場所:screenshotの保存場所の指定
     //撮影するボタン（スマホのUIボタン）
     //カメラの指定　
public class ScreenShotScript : MonoBehaviour {
    [SerializeField]
    KeyCode screenShotKey;
    string currentScreenShotDirectory;
    string filename;
    [SerializeField,Range(1,10)]
    int ResolutionRate;
    // Use this for initialization
    void Awake()
    {
        //exeのデータフォルダを取得
        currentScreenShotDirectory = Path.Combine(Application.persistentDataPath, "images");
        //もしもスクリーンショットフォルダが無い場合、
        //スクリーンショットフォルダの作成
        if (Directory.Exists(currentScreenShotDirectory) == false)
        {
            Directory.CreateDirectory(currentScreenShotDirectory);
        }
    }
	
	// Update is called once per frame
	void Update () {
        //スクリーンショットキーを押したらスクリーンショット関数起動
        if (Input.GetKeyDown(screenShotKey))
        {
            StartCoroutine(CaptureScreen());
        }
	}

    IEnumerator CaptureScreen()
    {
        filename = "";
        //現在時刻を取得、年月日時分秒を数値にし格納
        DateTime nowTime = DateTime.Now;
        int year = nowTime.Year;
        int month = nowTime.Month;
        int day = nowTime.Day;
        int hour = nowTime.Hour;
        int minite = nowTime.Minute;
        int second = nowTime.Second;

        //ファイル名の構築
        filename += year.ToString();
        filename += month.ToString();
        filename += day.ToString();
        filename += hour.ToString();
        filename += minite.ToString();
        filename += second.ToString();
        filename += "/PC/ダウンロード/scs/.png";
        
        //スクリーンショットのキャプチャ
        Application.CaptureScreenshot(Path.Combine(currentScreenShotDirectory,filename),ResolutionRate);
        //スクリーンショット撮影が終了するまで、
        //コルーチン自体が終了するのを抑制する
        while (!(File.Exists(filename)))
        {
            yield return null;
        }
        
    }
}
