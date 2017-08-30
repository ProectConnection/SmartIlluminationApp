using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour {

    [SerializeField]
    TimerScript com_SceneTimer;
    [SerializeField]
    Text ui_timer;

    int timer;

    void Start()
    {
        ui_timer.text = com_SceneTimer.timeLimit.ToString();
    }

	// Update is called once per frame
	void Update () {
        timer = (int)(com_SceneTimer.timeLimit - com_SceneTimer.nowTime);
        ui_timer.text = timer.ToString();
	}
}
