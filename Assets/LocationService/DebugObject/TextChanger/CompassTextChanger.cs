using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassTextChanger : MonoBehaviour {
    [SerializeField]
    Text Drawtarget;

	// Update is called once per frame
	void Update () {
        if (Drawtarget) Drawtarget.text = Input.compass.trueHeading.ToString("f6");
    }
}
