using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TItleMove : MonoBehaviour {

    [SerializeField]
    string NextScene;

	void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(NextScene);
        }
    }
}
