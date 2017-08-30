using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResultSceneMove : MonoBehaviour {
    [SerializeField]
    TimerScript Com_timer;
    [SerializeField]
    GameObject UI_anykey;
    [SerializeField]
    string NextScene;

    bool anykey_flg;
	// Update is called once per frame
	void Update () {
        if (anykey_flg == true)
        {
            if (Input.anyKeyDown){
                SceneManager.LoadScene(NextScene);
            }
        }
        else {
            if (Com_timer.nowTime >= Com_timer.timeLimit){
                anykey_flg = true;
                UI_anykey.SetActive(true);
            }
        }
        
	}
}
