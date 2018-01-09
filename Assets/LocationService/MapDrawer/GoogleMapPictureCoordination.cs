public class GoogleMapPictureCoordination {
    public uint zoomlevel;
    public uint x;
    public uint y;

    public GoogleMapPictureCoordination(uint tzoomlevel,uint tx,uint ty)
    {
        zoomlevel = tzoomlevel;
        x = tx;
        y = ty;
    }

    public static GoogleMapPictureCoordination CalculateMapCoordinationFromLetiAndLong(LocationCoordination coordination,uint basezoomlevel)
    {
        uint tx = (uint)System.Math.Round((coordination.GetLongitude + 180.0d) / (360.0d / System.Math.Pow(2,basezoomlevel)));
        uint ty = (uint)System.Math.Round((coordination.GetLatitude + 90.0d) / (180.0d / System.Math.Pow(2, basezoomlevel)));
        return new GoogleMapPictureCoordination(basezoomlevel, tx, ty);
    }

    public static LocationCoordination CalculateLetiAndLongFromMapCoordination(GoogleMapPictureCoordination tGmpc)
    {
        double divx = (360.0d / System.Math.Pow(2,tGmpc.zoomlevel));
        double divy = (180.0d / System.Math.Pow(2,tGmpc.zoomlevel));
        double tx = ((tGmpc.x * divx) + (divx / 2) - 180.0d);
        double ty = ((tGmpc.y * divy) + (divy / 2) - 90.0d);
        return new LocationCoordination(tx,ty);
    }
    public override string ToString()
    {
        return ("zoomlevel =" + zoomlevel + "\nx =" + x +"\ny =" + y);
    }
}
