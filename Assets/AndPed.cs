using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AndPed : MonoBehaviour {

    [SerializeField]
    public UnityEngine.UI.Text thisText;
    DataSaver ref_dataSaver;
    bool init = true;
    string initalSteps;
#if UNITY_ANDROID && !UNITY_EDITOR
    AndroidJavaObject androidPedometer; //歩数計管理クラス
    AndroidJavaClass serviceLauncher;   //歩数計サービスの起動クラス
#endif
    private void Start()
    {
        ref_dataSaver = DataSaver.GetDataSaver();
        //歩数計管理クラスをネイティブプラグイン側で起動する処理
#if UNITY_ANDROID && !UNITY_EDITOR
        serviceLauncher = new AndroidJavaClass("com.example.androidpedometer.ServiceLauncher");
        serviceLauncher.CallStatic("StartService");
        
#endif
        StartCoroutine(PedoUpdate());
    }

    public void GetStepsFromStepsensor()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
            string[] args = { gameObject.name, ((Action<string>)onCallBackShowResult).Method.Name};
            androidPedometer.Call("GetSteps",args);
#endif
    }

    /*歩数計からの歩数取得コルーチン*/
    IEnumerator PedoUpdate()
    {

#if UNITY_ANDROID && !UNITY_EDITOR
        androidPedometer = new AndroidJavaObject("com.example.androidpedometer.AndroidPedometer");
        androidPedometer.Call("StartPedometer");
#endif
        yield return new WaitForSeconds(2f);
        while (true)
        {
            GetStepsFromStepsensor();
            yield return new WaitForSeconds(0.08f);
        }
    }

    /*
    歩数計プラグインからの歩数受け取りコールバック関数
    
    string steps 歩数計プラグインからのメッセージ（歩数を文字列化したもの）
    メッセージは文字列のみでしか送れないため文字列で受け取る
    */
    public void onCallBackShowResult(string steps)
    {
        if (init)
        {
            init = false;   
            initalSteps = steps;

        }
        thisText.text = steps;

       float ts =  float.Parse(steps) - float.Parse(initalSteps);

        ref_dataSaver.SetNewPedocount(ts.ToString(), PEDOCOUNTSETMODE.ADDCITIVE);
    }

    
}

