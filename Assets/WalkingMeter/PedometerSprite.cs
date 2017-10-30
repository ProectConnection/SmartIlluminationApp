using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedometerSprite : MonoBehaviour {

   
    Image image;
    public Sprite ChangeSprite;

    //達成歩数設定（Step～Step_Achievement）
    DataSaver ref_DataSaver;
    public int Step;
    public int Step_Achievement;


    //************

#if UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void _ex_callSwiftMethod(string message);
#endif

    public static void CallSwiftMethod(string message)
    {
#if UNITY_IOS && !UNITY_EDITOR
        _ex_callSwiftMethod(message);
#endif
    }

    //************



    // Use this for initialization
    void Start () {

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
