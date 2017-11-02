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
    AndroidJavaObject javaObject;
#endif
    private void Start()
    {
        ref_dataSaver = DataSaver.GetDataSaver();
#if UNITY_ANDROID && !UNITY_EDITOR
        //javaObject = new AndroidJavaObject("com.example.androidpedometer.AndroidPedometer");
        
        //    Debug.Log(javaObject);
        //    Debug.Log(activity.ToString());
        //    object[] args = { gameObject.name, ((Action<string>)OnStartedPedometer).Method.Name, activity};
        //    javaObject.Call("StartPedometer",args);
        
#endif
        StartCoroutine(PedoUpdate());
    }

    public void callStaticFunction()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        // static methodを呼び出す
        //AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //using (AndroidJavaClass javaClass = new AndroidJavaClass("com.example.plugin.AndPlugin"))
        //{
        //    Debug.Log(javaClass);
        //    javaClass.CallStatic("staticFunction");
        //}
        //javaObject = new AndroidJavaObject("com.example.androidpedometer.AndroidPedometer");
        //    Debug.Log(javaObject);
            string[] args = { gameObject.name, ((Action<string>)onCallBackShowResult).Method.Name};
            javaObject.Call("GetSteps",args);
        
        //// non-static methodを呼び出す
        ////AndroidJavaObject plugin = new AndroidJavaObject("com.example.plugin");
        //AndroidJavaObject plugin = new AndroidJavaObject("com.example.plugin.AndPlugin");
        
        //// Android側の関数"staticFunction"の呼び出し
        //plugin.CallStatic("staticFunction");
#endif
    }

    IEnumerator PedoUpdate()
    {

#if UNITY_ANDROID && !UNITY_EDITOR
        
        javaObject = new AndroidJavaObject("com.example.androidpedometer.AndroidPedometer");
        AndroidJavaClass ActivaterActivity = new AndroidJavaClass("com.example.androidpedometer.ActivityLauncher");
        object[] aaArgs = { "com.example.androidpedometer.AndroidPedometer"};
        ActivaterActivity.CallStatic("launchActivity", aaArgs);
            //object[] args = { gameObject.name, ((Action<string>)OnStartedPedometer).Method.Name, activity};
            //javaObject.Call("StartPedometer",args);
#endif
        yield return new WaitForSeconds(2f);
        while (true)
        {
            callStaticFunction();
            yield return new WaitForSeconds(0.08f);
        }
    }

    // uGUIの"Call static Function"というボタンを押す
    // Android側の"staticFunction"というメソッドが呼ばれる
    // "staticFunction"から、Unityの"onCallBackShowResult"メソッドに対して文字列を返す
    // "onCallBackShowResult"メソッドがuGUIのTextに"step"を表示する
    public void onCallBackShowResult(string steps)
    {
        if (init)
        {
            init = false;   
            initalSteps = steps;

        }
        Debug.Log("(*‘ω‘ *)");
        thisText.text = steps;

       float ts =  float.Parse(steps) - float.Parse(initalSteps);

        ref_dataSaver.SetNewPedocount(ts.ToString(), PEDOCOUNTSETMODE.ADDCITIVE);
    }

    public void OnStartedPedometer(string message)
    {

    }

    public void hoge()
    {

    }

    //  UnityPlayer.UnitySendMessage("Text", "onCallBackShowResult", "steps");




    /*
        public class HogeClass {
            private static string JAVA_CLASS_NAME = "com.hoge.JHogeClass";

            public void Hoge() {
                using (AndroidJavaClass plugin = new AndroidJavaClass(JAVA_CLASS_NAME)) {
                    plugin.CallStatic("hogeNative");
                }
            }
        }

        //package com.hoge;

        public class JHogeClass {
            public static void hogeNative() {
            }
        }
        */

    }

