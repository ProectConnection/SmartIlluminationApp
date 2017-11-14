using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUnLock : MonoBehaviour {
    [SerializeField]
    UnityEngine.UI.InputField pass_inputField;
    TitleImageHit ref_TitleImageHit;
    string pass = "SIW_231-0002";
    [SerializeField]
    GameObject ref_InCorrectPassPopup;
	// Use this for initialization
	void Start () {
        ref_TitleImageHit = GetComponent<TitleImageHit>();
	}

    public void CheckPass()
    {
        if (pass_inputField.text == pass) {
            ref_TitleImageHit.OnPress();
            DataSaver.GetDataSaver().UnlockApp();
        }
        else ref_InCorrectPassPopup.SetActive(true);
    }
}
