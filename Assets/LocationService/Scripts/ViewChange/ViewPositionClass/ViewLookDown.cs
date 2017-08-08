using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewLookDown : ViewPosition{
    GameObject PointOfLookDown;
    
    public override void ViewChange(Camera ViewChangeTarget)
    {
        if (!PointOfLookDown) PointOfLookDown = GameObject.Find("PointOfLookDown");
        if (!Com_CameraCompassRotator) Com_CameraCompassRotator = GameObject.Find("BehindViewRotationTarget").GetComponent<CompassRotator>();
        if (!Com_PlayerCompassRotator) Com_PlayerCompassRotator = GameObject.FindGameObjectWithTag("Player").GetComponent<CompassRotator>();

        Com_CameraCompassRotator.enabled = false;
        Com_PlayerCompassRotator.enabled = true;

        ViewPointChange(ViewChangeTarget, PointOfLookDown);
        
    }
}
