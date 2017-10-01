public class LocationCoordination : UnityEngine.ScriptableObject{
    
    private double longitude;
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
}