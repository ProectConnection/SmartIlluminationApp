using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampClearMarkManager : MonoBehaviour {
    [SerializeField]
    GameObject[] ClearMark;
    [SerializeField]
    StampID[] reletiveStampIdValues;
    StampData ref_StampData;
	// Use this for initialization
	void Start () {
        ref_StampData = StampData.GetStampData;
        for(int i = 0;i < reletiveStampIdValues.Length;i++)
        {
            ClearMark[i].SetActive(ref_StampData.IsPressedStampById(reletiveStampIdValues[i]));
        }
        
	}
}
