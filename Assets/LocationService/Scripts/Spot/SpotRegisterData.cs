using UnityEngine;

//引数引き渡しを効率的に行うためのデータクラス
public class SpotRegisterData{
    public string spotUrl;
    public string spotName;
    public string ParentSavePass;
    public string savePass;
    public string fileName;
    public SpotType spotType;
    public StampID newStampId;
    public Sprite[] NextAddPhotoFrame;
    public int spotRange;

    public SpotRegisterData(string tspotUrl,
    string tspotName,
    string tParentSavePass,
    string tsavePass,
    string tfileName,
    SpotType tspotType,
    StampID tnewStampId,
    int tSpotRange,
    Sprite[] tNextAddPhotoFrame)
    {
        spotUrl = tspotUrl;
        spotName = tspotName;
        ParentSavePass = tParentSavePass;
        savePass = tsavePass;
        fileName = tfileName;
        spotType = tspotType;
        newStampId = tnewStampId;
        spotRange = tSpotRange;
        NextAddPhotoFrame = tNextAddPhotoFrame;
    }

    public SpotRegisterData(string tspotUrl,
    string tspotName,
    string tParentSavePass,
    string tsavePass,
    StampID tnewStampId,
    Sprite[] tNextAddPhotoFrame)
    {
        spotUrl = tspotUrl;
        spotName = tspotName;
        ParentSavePass = tParentSavePass;
        savePass = tsavePass;
        newStampId = tnewStampId;
        NextAddPhotoFrame = tNextAddPhotoFrame;
    }
};
