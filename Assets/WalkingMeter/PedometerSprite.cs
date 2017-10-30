using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class PedometerSprite : MonoBehaviour {

   
    Image image;
    public Sprite ChangeSprite;

    //達成歩数設定（Step～Step_Achievement）
    public int Step;
    public int Step_Achievement;


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



    // Use this for initialization
    void Start () {
       

        image = GetComponent<Image>();


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

        if (Step >= Step_Achievement)
        {
           
            image.sprite = ChangeSprite;

        }
       

    }
    




}
