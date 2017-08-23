using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

    [SerializeField]
    float TimeLimit;
    float NowTime;
    bool IsStop;

    TimerScript()
    {
        NowTime = 0.0f;
    }

    public float timeLimit
    {
        get
        {
            return TimeLimit;
        }
    }

    public float nowTime
    {
        get
        {
            return NowTime;
        }
        set
        {
            NowTime = value;
        }
    }

    public bool isStop
    {
        get
        {
            return IsStop;
        }
        set
        {
            IsStop = value;
        }
    }

    void Update()
    {
        if(isStop == false)
        {
            nowTime += Time.deltaTime;
        }
    }
}
