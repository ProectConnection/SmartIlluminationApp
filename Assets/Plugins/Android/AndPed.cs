using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndPed : MonoBehaviour {

    [SerializeField]
   public Text text;

    public void callStaticFunction()
    {
        // static methodを呼び出す
        //AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        using (AndroidJavaClass javaClass = new AndroidJavaClass("com.example.plugin.AndPlugin")) ;
        
        // non-static methodを呼び出す
        //AndroidJavaObject plugin = new AndroidJavaObject("com.example.plugin");
        AndroidJavaObject plugin = new AndroidJavaObject("com.example.plugin.AndPlugin");
        
        // Android側の関数"staticFunction"の呼び出し
        plugin.CallStatic("staticFunction");
        
    }

    // uGUIの"Call static Function"というボタンを押す
    // Android側の"staticFunction"というメソッドが呼ばれる
    // "staticFunction"から、Unityの"onCallBackShowResult"メソッドに対して文字列を返す
    // "onCallBackShowResult"メソッドがuGUIのTextに"step"を表示する
    public void onCallBackShowResult(string steps)
    {
        text.text = steps;
        GameObject.FindGameObjectWithTag("Pedometer");
        Debug.Log("(*‘ω‘ *)");

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

