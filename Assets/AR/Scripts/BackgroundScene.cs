using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackgroundScene : MonoBehaviour {
    [SerializeField]
    string BackLoadSceneName;

	void Awake()
    {
        if (SceneManager.GetSceneByName(BackLoadSceneName).isLoaded == false)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(BackLoadSceneName, LoadSceneMode.Additive);
        }
    }
}
