using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToPrevousMap : MonoBehaviour {
    [SerializeField]
    string usedScene;
    bool isProcessing = false;
	public void OnPress()
    {
        if (!isProcessing)
        {
            isProcessing = true;
            //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            SceneManager.UnloadSceneAsync(usedScene);
            SceneManager.LoadSceneAsync("MapScene", LoadSceneMode.Additive);
        }
    }
}
