﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Renderer))]
public class SpotClass : MonoBehaviour {
    Transform gameObjectTransform;
    Renderer thisRenderer;
    GameObject ChildrenSpotRange;
    MapSpotVisilizer mapSpotVisilizer;
    TextMesh ThisSpotNameText;
    Renderer ThisSpotNameTextRenderer;
    public Transform thisTransform
    {
        get
        {
            return gameObjectTransform;
        }
    }

    [SerializeField]
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
            ThisSpotNameTextRenderer.enabled = value;
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
    private void Awake()
    {
        gameObjectTransform = gameObject.transform;
        thisRenderer = GetComponent<Renderer>();
        ChildrenSpotRange = gameObjectTransform.GetChild(1).gameObject;
        ThisSpotNameText = gameObjectTransform.GetChild(0).gameObject.GetComponent<TextMesh>();
        ThisSpotNameTextRenderer = ThisSpotNameText.gameObject.GetComponent<Renderer>();
        
    }
    private void Start()
    {
        ThisSpotNameText.text = ThisSpotData.SpotName;
        mapSpotVisilizer = GameObject.FindGameObjectWithTag("MapDrawer").GetComponent<MapSpotVisilizer>();
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

    public void ChangeScaleSpotRange()
    {
        Vector3 newScale;
        Transform childrenTransform = ChildrenSpotRange.transform;
        newScale = new Vector3(2 * (thisSpotData.spotActivateDistance / mapSpotVisilizer.mapMeterPerOneUnit.x),
                               childrenTransform.localScale.y,
                               2 * (thisSpotData.spotActivateDistance / mapSpotVisilizer.mapMeterPerOneUnit.y));
        childrenTransform.localScale = newScale;
    }
}
