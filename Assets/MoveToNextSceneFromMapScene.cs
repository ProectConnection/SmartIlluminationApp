using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextSceneFromMapScene: MonoBehaviour
{
    [SerializeField]
    string sceneName;
    public void OnPress()
    {
        SceneManager.UnloadSceneAsync("MapScene");
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
}