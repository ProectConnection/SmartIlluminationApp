using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saecoPedometer : MonoBehaviour {
#if UNITY_ANDROID && !UNITY_EDITOR
    static AndroidJavaClass m_plugin;
#endif
    public static void CallstaticFunction(string steps)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (m_plugin != null){
            m_plugin.Call("staticFunction", steps);
        }
#endif
    }

    // Use this for initialization
    void Start () {
        //#if UNITY_ANDROID && !UNITY_EDITOR
        //        m_plugin = new AndroidJavaClass("xyz.saeco.pedometer.MainActivity");
        //#endif
    }
}
