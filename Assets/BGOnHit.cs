using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGOnHit : MonoBehaviour {
    [SerializeField]
    GameObject ref_EventUnlockPopUp;
    TitleImageHit ref_TitleImageHit;
    private void Start()
    {
         ref_TitleImageHit = GetComponent<TitleImageHit>();
    }

    public void OnPress()
    {
        if (!(DataSaver.GetDataSaver().isUnlocked)) {
            ref_EventUnlockPopUp.SetActive(true);
        }
        else { ref_TitleImageHit.OnPress(); }
    }
}
