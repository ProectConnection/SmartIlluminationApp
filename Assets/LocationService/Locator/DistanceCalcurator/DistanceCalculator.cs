using System.Collections;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour {

    DVector2 PrevPositionInMetrics;
    double totalMoveDistance;
    bool isFirstTime = true;

    double SpeedPerHour;
    [SerializeField, Range(0, 60)]
    float WalkingSpeedPerHour;
    [SerializeField,Range(0,60)]
    float RunningSpeedPerHour;
    [SerializeField]
    float waitsecond;
    public double TotalMoveDistance
    {
        get { return totalMoveDistance; }
    }

    LocationCoordination ref_locationCoordination;

    private void Start()
    {
        ref_locationCoordination = GameObject.FindGameObjectWithTag("Locator").GetComponent<Locator>().locationCoordination;
        WalkingSpeedPerHour *= 1000.0f;
        RunningSpeedPerHour *= 1000.0f;
    }

    public void DistanceCalculation()
    {
        if (isFirstTime)
        {
            PrevPositionInMetrics = new DVector2(ref_locationCoordination.GetLongitude, ref_locationCoordination.GetLatitude);
            isFirstTime = false;
        }
        else
        {
            DVector2 a = new DVector2(ref_locationCoordination.GetLongitude, ref_locationCoordination.GetLatitude);
            DVector2 b = new DVector2(PrevPositionInMetrics.x, PrevPositionInMetrics.y);
            double moveDistance = long_lati_calculator.GetInstance.CalculateLetiAndLongDistanceOfAtoB(a, b);
            SpeedPerHour = moveDistance * (3600 / waitsecond);
            if (SpeedPerHour >= WalkingSpeedPerHour && SpeedPerHour < RunningSpeedPerHour) totalMoveDistance += moveDistance;
            PrevPositionInMetrics = new DVector2(a.x, a.y);
        }
    }

    IEnumerator ProcessDistanceCalculation()
    {
        while (true)
        {
            DistanceCalculation();
            yield return new WaitForSeconds(waitsecond);
        }
    }
}
