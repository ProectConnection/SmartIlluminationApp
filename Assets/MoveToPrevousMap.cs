using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToPrevousMap : MonoBehaviour {
    [SerializeField]
    string usedScene;
	public void OnPress()
    {
        //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.UnloadSceneAsync(usedScene);
        SceneManager.LoadSceneAsync("MapScene",LoadSceneMode.Additive);
    }
}
