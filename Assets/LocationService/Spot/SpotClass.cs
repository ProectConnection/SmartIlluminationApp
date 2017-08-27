using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Renderer))]
public class SpotClass : MonoBehaviour {
    Transform gameObjectTransform;
    Renderer thisRenderer;
    
    public Transform thisTransform
    {
        get
        {
            return gameObjectTransform;
        }
    }

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

    bool IsVisible = true;
    public bool visible
    {
        get
        {
            return IsVisible;
        }
        set
        {
            thisRenderer.enabled = value;
            IsVisible = value;
        }
    }

    bool IsSpotNearPlayer = false;
    public bool isSpotNearPlayer
    {
        get
        {
            return IsSpotNearPlayer;
        }
        set
        {
            IsSpotNearPlayer = value;
        }
    }

    private void Start()
    {
        gameObjectTransform = gameObject.transform;
        thisRenderer = GetComponent<Renderer>();   
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

    public void SpotIntaract()
    {
        //プレイヤーとスポットの距離が一定範囲内かどうかによって処理を変える
        if (isSpotNearPlayer)
        {
            thisRenderer.material.color = Color.blue;
        }
        else
        {

        }
            
    }
}
