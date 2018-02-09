using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimiter : MonoBehaviour {
    Transform thisTransform;
    [SerializeField]
    float[] udLimit;
    [SerializeField]
    float[] lrLimit;
    Vector3 tempVec3;

    Transform ref_GoogleMapDrawer;
	// Use this for initialization
	void Start () {
        thisTransform = gameObject.transform;
        ref_GoogleMapDrawer = GameObject.FindGameObjectWithTag("CentMapDrawer").transform;
	}
	
	// Update is called once per frame
	void Update () {
        tempVec3 = thisTransform.position;
		if(thisTransform.position.x >= lrLimit[1] * ref_GoogleMapDrawer.localScale.x)
        {
            tempVec3.x = lrLimit[1];
            thisTransform.position = tempVec3;
        }
        else if (thisTransform.position.x <= lrLimit[0] * ref_GoogleMapDrawer.localScale.x)
        {
            tempVec3.x = lrLimit[0];
            thisTransform.position = tempVec3;
        }
        if (thisTransform.position.z >= udLimit[0] * ref_GoogleMapDrawer.localScale.z)
        {
            tempVec3.z = udLimit[0];
            thisTransform.position = tempVec3;
        }
        else if (thisTransform.position.z <= udLimit[1] * ref_GoogleMapDrawer.localScale.z)
        {
            tempVec3.z = udLimit[1];
            thisTransform.position = tempVec3;
        }

    }
}
