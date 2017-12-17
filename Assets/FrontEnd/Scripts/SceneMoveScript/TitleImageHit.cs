using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleImageHit : MonoBehaviour{
    //UnityEngine.UI.Image image;
    UnityEngine.UI.Button parentButton;
    private void Start()
    {
         parentButton = gameObject.GetComponent<UnityEngine.UI.Button>();
        parentButton.onClick.AddListener(OnPress);
    }

    public void OnPress()
    {
        SceneManager.UnloadSceneAsync("Title");
        SceneManager.LoadScene("LocationServiceBackGround", LoadSceneMode.Additive);
        SceneManager.LoadScene("MapScene",LoadSceneMode.Additive);
    }

    
}
