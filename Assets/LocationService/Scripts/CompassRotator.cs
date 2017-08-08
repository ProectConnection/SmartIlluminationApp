using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassRotator : MonoBehaviour {

    Transform rotationObject;
    float rotation_Yaw;
    [SerializeField]
    uint rotationSplit_num = 36;
    float rotationSplitDegrees;

    [SerializeField]
    float rotationUpdateSecond = 1.0f;
    bool conpassActive = true;

    // Use this for initialization
    void Start () {
        rotationObject = gameObject.transform;
        Input.compass.enabled = true;
        rotationSplitDegrees = (360f / rotationSplit_num);

        StartCoroutine(GetCompassTrueHeading());
    }
	// Update is called once per frame
	void Update () {
        
    }

   IEnumerator GetCompassTrueHeading()
    {
        while (true)
        {
            UpdateRotationYaw();
            UpdateRotationYawToRotationObject();
            yield return new WaitForSeconds(rotationUpdateSecond);
        }
    }

    void UpdateRotationYaw()
    {
        rotation_Yaw = Input.compass.trueHeading;        
    }

    void UpdateRotationYawToRotationObject()
    {
        if (rotationSplitDegrees == 0) rotation_Yaw = 0;
        else rotation_Yaw = (Mathf.Floor(rotation_Yaw / rotationSplitDegrees) * rotationSplitDegrees);
        rotationObject.rotation = Quaternion.Euler(rotationObject.rotation.x, rotation_Yaw, rotationObject.rotation.z);
    }


}
/*
 while (conpassActive)
        {
            
            //if (rotationSplitDegrees == 0) rotation_Yaw = 0;
            //else rotation_Yaw = (Mathf.Floor(rotation_Yaw / rotationSplitDegrees) * rotationSplitDegrees);
            //rotationObject.parent.rotation = Quaternion.Euler(rotationObject.parent.rotation.x, rotation_Yaw, rotationObject.parent.rotation.z);
            yield return new WaitForSeconds(rotationUpdateSecond);
        }
     */
