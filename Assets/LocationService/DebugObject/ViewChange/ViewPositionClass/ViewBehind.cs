using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBehind : ViewPosition{
    GameObject PointOfBehind;
    public override void ViewChange(Camera ViewChangeTarget)
    {
        if(!PointOfBehind) PointOfBehind = GameObject.Find("PointOfBehind");
        if (!Com_CameraCompassRotator) Com_CameraCompassRotator = GameObject.Find("BehindViewRotationTarget").GetComponent<CompassRotator>();
        if (!Com_PlayerCompassRotator) Com_PlayerCompassRotator = GameObject.FindGameObjectWithTag("Player").GetComponent<CompassRotator>();

        Com_CameraCompassRotator.enabled = true;
        Com_PlayerCompassRotator.enabled = false;

        ViewPointChange(ViewChangeTarget, PointOfBehind);
    }
}
