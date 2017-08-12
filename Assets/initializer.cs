using UnityEngine;
using UnityEngine.SceneManagement;

public class initializer : MonoBehaviour {
    private void Awake()
    {
        SceneManager.LoadScene("Title",LoadSceneMode.Additive);
    }
}
