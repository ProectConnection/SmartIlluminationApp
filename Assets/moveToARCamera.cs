using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveToARCamera : MonoBehaviour {

	void OnPress()
    {
        SceneManager.LoadSceneAsync("ARCamera",LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("MapScene");
    }
}