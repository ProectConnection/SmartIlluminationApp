using UnityEngine;

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

    public Vector2 GetSpotCoordInVec2
    {
        get
        {
            return new Vector2(longitude, letitude);
        }
    }
}
