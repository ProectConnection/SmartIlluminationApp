using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverTimer : MonoBehaviour {
    [SerializeField]
    TimerScript com_TimerScript;
    [SerializeField]
    PouseManager com_PouseManager;
    [SerializeField]
    bool isFinished;
    [SerializeField]
    PosableObject posableObject;
    [SerializeField]
    string EndingScene;
    [SerializeField]
    float EndingSecond;
    [SerializeField]
    GameObject UI_Sokomade;

    float EndCount;
    
    public bool IsFinished
    {
        get
        {
            return isFinished;
        }
    }

	// Update is called once per frame
	void Update () {
        if(com_TimerScript.timeLimit <= com_TimerScript.nowTime)
        {
            //ゲームオーバー時の処理を記述
            //com_PouseManager.SetPouse(true);
            //Time.timeScale = 0.0f;
            posableObject.pousing = true;
            StartCoroutine(EndTimeCorutine());
        }
	}
    /*
     エンディング遷移用のコルーチン
    */
    IEnumerator EndTimeCorutine()
    {
        UI_Sokomade.SetActive(true);
        while (true)
        {
            EndCount += Time.deltaTime;

            if (EndCount >= EndingSecond)
            {
                SceneManager.LoadScene(EndingScene);
                break;
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
