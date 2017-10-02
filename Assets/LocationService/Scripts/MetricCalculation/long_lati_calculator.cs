using System;
using UnityEngine;

public sealed class long_lati_calculator {

    public const int Equator = 6378137;        //赤道半径
    public const int EarthRadius = 6356752;    //極半径
    public int earthRadius = EarthRadius;    //極半径
    float LongitudeMetricsPerDegree = (2.0f * Mathf.PI * EarthRadius) / 360;
    public float longitudeMetricsPerDegree
    {
        get{ return LongitudeMetricsPerDegree; }
    }

    private static long_lati_calculator thisinstance = new long_lati_calculator();

    private long_lati_calculator()
    {

    }

    static public long_lati_calculator GetInstance
    {
        get { return thisinstance; }
    }

    public float CalculateLatitudeMetricParDegree(float Letitude)
    {
        return  (2.0f * Mathf.PI * (Equator * Mathf.Cos(Letitude * Mathf.PI / 180.0f ))) / 360;
    }
    public double CalculateMetricLatitudeR(double Letitude)
    {
        return (2.0f * Math.PI * (Equator * Math.Cos(Letitude * Math.PI / 180.0f)));
    }
    
    private double haversine(double r,double dax, double day, double dbx, double dby)
    {
        double rax = DegToRad(dax);
        double ray = DegToRad(day);
        double rbx = DegToRad(dbx);
        double rby = DegToRad(dby);
        return 2 * r * (
                Math.Asin(
                    Math.Sqrt(
                        (Math.Sin((rbx - rax) / 2) * Math.Sin((rbx - rax) / 2)) +
                        (Math.Cos(rax)) * (Math.Cos(rbx)) *
                        (Math.Sin((rby - ray) / 2) * Math.Sin((rby - ray) / 2))
                    )
                )
              );
    }

    

    public double CalculateLetiAndLongDistanceOfAtoB(DVector2 a,DVector2 b)
    {

        return haversine((Equator + EarthRadius) / 2, a.x, a.y, b.x, b.y);
    }

    public static double DegToRad(double Deg) {
        return Deg * Math.PI / 180;
    }


    public DVector2 CalculateLetiAndLongDifferenceOfAtoB(DVector2 a, DVector2 b)
    {
        //return new Vector2((GetInstance.longitudeMetricsPerDegree * (a.x - b.x)),
        //                   (GetInstance.CalculateLatitudeMetricParDegree((a.y + b.y ) / 2) * (a.y - b.y))
        //                   );
        Debug.Log("a = " + a);
        Debug.Log("b = " + b);   
        double rax = DegToRad(a.x);
        double ray = DegToRad(a.y);
        double rbx = DegToRad(b.x);
        double rby = DegToRad(b.y);
        return new DVector2(
                            (float)(2 * EarthRadius * (Math.Asin((Math.Sin((rbx - rax) / 2)) +
                            (Math.Cos(rax)) * (Math.Cos(rbx))
                            *(Math.Sin((0.0 - 0.0) / 2)))
                                    ))
              ,
                             (float)(2 * EarthRadius * (
                                            Math.Asin(
                                                     
                                                              (Math.Sin((0.0- 0.0) / 2)) +
                                                              (Math.Cos(0.0)) * (Math.Cos(0.0)) *
                                                              (Math.Sin((rby - ray) / 2))
                                                              )
                                                     
                                            )
                                   )
                     );
    }
}
