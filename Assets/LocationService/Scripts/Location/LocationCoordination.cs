using UnityEngine;

[System.Serializable]
public class LocationCoordination {
    [SerializeField]
    private double longitude;
    [SerializeField]
    private double latitude;
    
    public void SetCoordination(double tlongitude,double tlatitude)
    {
        longitude = tlongitude;
        latitude = tlatitude;
    }

    public double GetLongitude
    {
        get{ return longitude; }
    }

    public double GetLatitude
    {
        get { return latitude; }
    }

    public DVector2 GetLocationCoordInVec2
    {
        get { return new DVector2(longitude, latitude); }
    }

    public UnityEngine.Event OnCoordinationChange;

    public LocationCoordination()
    {
        SetCoordination(0.0, 0.0);
    }

    public LocationCoordination(double tlongitude,double tlatitude)
    {
        SetCoordination(tlongitude, tlatitude);
    }

    public LocationCoordination(DVector2 CoordinationDegrees)
    {
        SetCoordination(CoordinationDegrees.x, CoordinationDegrees.y);
    }

    public override string ToString()
    {
        return ("Letitude =" + latitude + "Longitude" + longitude);
    }
}