using UnityEngine;

public abstract class ViewPosition : ScriptableObject
{
    protected CompassRotator Com_CameraCompassRotator;
    protected CompassRotator Com_PlayerCompassRotator;

    public abstract void ViewChange(Camera ViewChangeTarget);
    protected void ViewPointChange(Camera ViewChangeTarget,GameObject attachPoint)
    {
        //rotationとpositionの変更を一度にできないだろうか？
        ViewChangeTarget.gameObject.transform.position = attachPoint.transform.position;
        ViewChangeTarget.gameObject.transform.rotation = attachPoint.transform.rotation;
    }
}