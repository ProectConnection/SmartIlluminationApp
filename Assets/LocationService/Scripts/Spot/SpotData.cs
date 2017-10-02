using UnityEngine;

[CreateAssetMenu(fileName = "SpotData", menuName = "SpotAsset",order = 1)]
public class SpotData : ScriptableObject{
    [SerializeField]
    string spotName;
    public string SpotName
    {
        get{ return spotName; }
    }

    [SerializeField]
    double Longitude;
    public double longitude
    {
        get { return Longitude; }
    }

    [SerializeField]
    double Letitude;
    public double letitude
    {
        get { return Letitude; }
    }

    [SerializeField]
    float SpotActivateDistance = 75.0f;
    [SerializeField]
    Sprite[] PhotoFrame; //チェックポイントで写真撮影する際に映るフレーム類
    public Sprite[] photoFrames
    {
        get { return PhotoFrame; }
    }

    public Sprite GetPhotoFrame(int index)
    {
        return PhotoFrame[index];
    }

    [SerializeField]
    StampID StampIDThisCheckPoint;
    public StampID stampId
    {
        get { return StampIDThisCheckPoint; }
    }

    [SerializeField]
    SpotType ThisSpotType;
    public SpotType spotType
    {
        get { return ThisSpotType; }
    }

    public float spotActivateDistance
    {
        get { return SpotActivateDistance; }
    }

    public DVector2 GetSpotCoordInDVec2
    {
        get { return new DVector2(longitude, letitude); }
    }

    public void SetNewDatas(string tname,double tLongitude,double tLetitude)
    {
        spotName = tname;
        Longitude = tLongitude;
        Letitude = tLetitude;

    }
    public void SetNewDatas(string tname, double tLongitude, double tLetitude,StampID tstampId)
    {
        SetNewDatas(tname, tLongitude, tLetitude);
        StampIDThisCheckPoint = tstampId;
    }

    public void SetNewDatas(string tname, double tLongitude, double tLetitude, StampID tstampId,Sprite[] tPhotoFrame)
    {
        SetNewDatas(tname, tLongitude, tLetitude,tstampId);
        PhotoFrame = tPhotoFrame;
    }
    public void SetNewDatas(SpotRegisterData srData, double tLongitude, double tLetitude)
    {
        SetNewDatas(srData.spotName, tLongitude, tLetitude, srData.newStampId,srData.NextAddPhotoFrame);
        ThisSpotType = srData.spotType;
        SpotActivateDistance = srData.spotRange;
    }
}