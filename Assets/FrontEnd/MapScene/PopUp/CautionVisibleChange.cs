using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CautionVisibleChange : MonoBehaviour {
    DataSaver ref_dataSaver;
	// Use this for initialization
	void Start () {
        ref_dataSaver = DataSaver.GetDataSaver();
        if (ref_dataSaver.isAlreadyLoadMap)
        {
            gameObject.SetActive(false);
        }
        ref_dataSaver.isAlreadyLoadMap = true;
	}
}
