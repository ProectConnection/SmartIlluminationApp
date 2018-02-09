using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextSceneFromMapScene: MonoBehaviour
{
    [SerializeField]
    string sceneName;
    bool m_isProcessing = false;
    public void OnPress()
    {
        if (!m_isProcessing)
        {
            m_isProcessing = true;
            SceneManager.UnloadSceneAsync("MapScene");
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
    }
}