using UnityEngine;
using System.Collections;

public class BreakBullet : MonoBehaviour {

    [SerializeField]
    TimerScript Com_Timer;
	// Update is called once per frame
	void Update () {
	    if(Com_Timer.nowTime >= Com_Timer.timeLimit)
        {
            Destroy(gameObject);
        }
	}
}
