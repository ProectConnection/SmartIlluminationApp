using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class SpotClass : MonoBehaviour {
    Transform gameObjectTransform;
    SpotData thisSpotData;
    bool IsActivate = false;

    public bool isActivate
    {
        get
        {
            return IsActivate;
        }

        set
        {
            //アクティベーション処理をここで行う？
        }
    }

    private void Start()
    {
        gameObjectTransform = gameObject.transform;
    }

    public void SetWorldPosition(Vector3 newPosition)
    {
        gameObjectTransform.position = newPosition;
    }

    public void SetThisSpotData(SpotData NextSpotData)
    {
        thisSpotData = NextSpotData;
    }

    public SpotData ThisSpotData
    {
        get
        {
            return thisSpotData;
        }
    }

    public Vector3 GetWorldPosition()
    {
        return gameObjectTransform.position;
    }
}
