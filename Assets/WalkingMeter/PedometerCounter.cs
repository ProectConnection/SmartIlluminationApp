﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedometerCounter : MonoBehaviour {
    Text thisText;
    DataSaver ref_DataSaver;
	// Use this for initialization
	void Start () {
        thisText = GetComponent<Text>();
        ref_DataSaver = DataSaver.GetDataSaver();
	}
	
	// Update is called once per frame
	void Update () {
        thisText.text = ref_DataSaver.Pedocount.ToString();
	}
}
