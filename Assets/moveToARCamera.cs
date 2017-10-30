using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveToARCamera : MonoBehaviour {
    bool processing = false;
	void OnPress()
    {
        if (!processing)
        {
            processing = true;
            SceneManager.LoadSceneAsync("ARCamera", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("MapScene");
        }
    }
}