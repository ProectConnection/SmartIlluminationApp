using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class PedometerSprite : MonoBehaviour {

   
    Image image;
    public Sprite ChangeSprite;

    //達成歩数設定（Step～Step_Achievement）
    DataSaver ref_DataSaver;
    public int Step;
    public int Step_Achievement;
#if UNITY_ANDROID && !UNITY_EDITOR
    static AndroidJavaClass m_plugin;
#endif

    //************

#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern void _ex_callSwiftMethod(string CMPedmeter);
#endif

    public static void _ex_CallSwiftMethod(string CMPedmeter)
    {
#if UNITY_IOS && !UNITY_EDITOR
        _ex_callSwiftMethod(CMPedmeter);
#endif
    }

    //************



    //************

    public static void CallstaticFunction(string steps)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (m_plugin != null){
            m_plugin.Call("staticFunction", steps);
        }
#endif
    }


    //************

    // Use this for initialization
    void Start () {
#if UNITY_ANDROID && !UNITY_EDITOR
        m_plugin = new AndroidJavaClass("xyz.saeco.pedometer.MainActivity");
#endif
        ref_DataSaver = DataSaver.GetDataSaver();
        image = GetComponent<Image>();
        Check();
    }
	
	// Update is called once per frame
	void Update () {


        //テスト用カウント
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Step += 1000;
            Check();
        }



    }

    public void Check()
    {

        if (ref_DataSaver.Pedocount >= Step_Achievement)
        {
           
            image.sprite = ChangeSprite;

        }
       

    }
    




}
