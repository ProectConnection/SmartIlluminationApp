using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    void Awake()
    {

        // プラグインの呼び出し
        plugin.CallstaticFunction(" call CallstaticFunction ");
    }


    public void onCallBackShowResult(string steps)
    {
        GameObject obj = GameObject.Find("/DebugConsole/Text");
        Text textComponent = obj.GetComponent<Text>();
        textComponent.text = steps;
    }


    /*public void onCallBackShowResult(string steps)
    {
        Debug.Log("Call From Native. (" + steps + ")");
    }*/

}
