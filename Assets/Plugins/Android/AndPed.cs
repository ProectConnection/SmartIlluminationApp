using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndPed : MonoBehaviour {

    [SerializeField]
    //private Text text;

    public void callStaticFunction()
    {
        // AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        // using (AndroidJavaClass javaClass = new AndroidJavaClass("com.example.plugin.AndPlugin");
        // 呼び込み
        AndroidJavaObject plugin = new AndroidJavaObject("com.example.plugin");
        //AndroidJavaObject plugin = new AndroidJavaObject("com.example.plugin.AndPlugin");
        // 関数の呼び出し
        plugin.CallStatic("staticFunction");
    }

    //public void onCallBackShowResult (string resultText);
    //text.text = resultText;


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

