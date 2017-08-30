using UnityEngine;
using System.Collections;

public enum ELEMENT
{
    NORMAL,
    MUSIC,
    SPORT,
    TEATHER
}



public class Element : MonoBehaviour {

    [SerializeField]
    bool[] MatchElement;

    

    public bool[] GetMatchElement()
    {
        return MatchElement;
    }

    public bool IsMatchElement(int ElementNo = 0)
    {
        return MatchElement[ElementNo];
    }

    public void SetMatchElement(int ElementNo,bool NextStat = false)
    {
        MatchElement[ElementNo] = NextStat;
    }

    
}