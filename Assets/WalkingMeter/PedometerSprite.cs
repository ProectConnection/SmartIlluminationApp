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

    //************

    // Use this for initialization
    void Start () {

        ref_DataSaver = DataSaver.GetDataSaver();
        image = GetComponent<Image>();
        Check();
    }
        
    public void Check()
    {

        if (ref_DataSaver.Pedocount >= Step_Achievement)
        {
            image.sprite = ChangeSprite;
        }

    }
    




}
