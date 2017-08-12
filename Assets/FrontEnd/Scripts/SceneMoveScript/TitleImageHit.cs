using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleImageHit : MonoBehaviour{
    //UnityEngine.UI.Image image;

    public void OnPress()
    {
        SceneManager.UnloadSceneAsync("Title");
        SceneManager.LoadScene("LocationServiceBackGround", LoadSceneMode.Additive);
        SceneManager.LoadScene("MapScene",LoadSceneMode.Additive);

    }

    
}
