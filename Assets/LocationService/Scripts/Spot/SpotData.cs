﻿using UnityEngine;

[CreateAssetMenu(fileName = "SpotData", menuName = "SpotAsset",order = 1)]
public class SpotData : ScriptableObject{
    [SerializeField]
    string spotName;
    public string SpotName
    {
        get
        {
            return spotName;
        }
    }

    [SerializeField]
    float Longitude;
    public float longitude
    {
        get
        {
            return Longitude;
        }
    }

    [SerializeField]
    float Letitude;
    public float letitude
    {
        get
        {
            return Letitude;
        }
    }

    [SerializeField]
    float SpotActivateDistance = 75.0f;
    [SerializeField]
    Texture2D[] PhotoFrame; //チェックポイントで写真撮影する際に映るフレーム類
    public Texture2D[] photoFrames
    {
        get
        {
            return PhotoFrame;
        }
    }

    public Texture2D GetPhotoFrame(int index)
    {
        return PhotoFrame[index];
    }

    [SerializeField]
    StampID StampIDThisCheckPoint;
    public StampID stampId
    {
        get
        {
            return StampIDThisCheckPoint;
        }
    }

    [SerializeField]
    SpotType ThisSpotType;
    public SpotType spotType
    {
        get
        {
            return ThisSpotType;
        }
    }

    

    public float spotActivateDistance
    {
        get
        {
            return SpotActivateDistance;
        }
    }

    public Vector2 GetSpotCoordInVec2
    {
        get
        {
            return new Vector2(longitude, letitude);
        }
    }

    public void SetNewDatas(string tname,float tLongitude,float tLetitude)
    {
        spotName = tname;
        Longitude = tLongitude;
        Letitude = tLetitude;

    }
    public void SetNewDatas(string tname, float tLongitude, float tLetitude,StampID tstampId)
    {
        SetNewDatas(tname, tLongitude, tLetitude);
        StampIDThisCheckPoint = tstampId;
    }

    public void SetNewDatas(string tname, float tLongitude, float tLetitude, StampID tstampId,Texture2D[] tPhotoFrame)
    {
        SetNewDatas(tname, tLongitude, tLetitude,tstampId);
        PhotoFrame = tPhotoFrame;
    }
}