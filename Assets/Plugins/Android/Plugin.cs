using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plugin : MonoBehaviour
{

    // Androidのメソッドを呼び出す
    public static void CallstaticFunction(string steps)
    {

#if UNITY_EDITOR
// Do not process with unityEditor

#elif UNITY_ANDROID
     AndroidJavaObject obj = new AndroidJavaObject("xyz.saeco.pedometer");
     obj.Call ("staticFunction", "Main", steps);
        
#endif


    }
}