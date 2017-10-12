using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampData : MonoBehaviour {

    List<StampID> PressedStamp = new List<StampID>();

    public List<StampID> pressedStamp
    {
        get { return PressedStamp; }
        set { PressedStamp = value; }
    }

    // Use this for initialization
    void Start () {
		
	}

    public static StampData GetStampData
    {
        get { return GameObject.FindGameObjectWithTag("StampData").GetComponent<StampData>(); }
    }

    public bool IsPressedStampById(StampID checkId)
    {
        if (checkId == StampID.undefined) return false;
        foreach (StampID tId in pressedStamp) if (checkId == tId) return true;
        return false;
    }

    public void StampPress()
    {
        GameObject SpotStamp = GameObject.FindGameObjectWithTag("SpotManager");
        SpotData neareSpotData = SpotStamp.GetComponent<SpotManager>().nearestSpotData;


        if (!IsPressedStampById(neareSpotData.stampId))
        {
            Debug.Log("pressedStamp.Count" + pressedStamp.Count);
            pressedStamp.Add(neareSpotData.stampId);
        }      
    }
}
