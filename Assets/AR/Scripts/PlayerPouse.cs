using UnityEngine;
using System.Collections;

public class PlayerPouse : MonoBehaviour {
    [SerializeField]
    PosableObject posableObject;
    [SerializeField]
    GameOverTimer Com_gameOverTimer;
    
    bool ButtonPress;
    bool PousePress;
    // Update is called once per frame
    void Update () {
        
	    if(Input.GetAxis("PouseMenu") != 0.0f)
        {
            if(ButtonPress == false && Com_gameOverTimer.IsFinished == false)
            {
                if (PousePress == false)
                {
                    //ポーズメニュー呼び出し
                    posableObject.pousing = true;
                    PousePress = true;
                }
                else
                {
                    //ポーズメニュー消去
                    posableObject.pousing = false;
                    PousePress = false;
                }
                ButtonPress = true;
            }
            
        }
        else
        {
            ButtonPress = false;
        }
	}
}
