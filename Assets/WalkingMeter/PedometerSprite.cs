using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedometerSprite : MonoBehaviour {

   
    Image image;
    public Sprite ChangeSprite;

    //達成歩数設定（Step～Step_Achievement）
    public int Step;
    public int Step_Achievement;


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
