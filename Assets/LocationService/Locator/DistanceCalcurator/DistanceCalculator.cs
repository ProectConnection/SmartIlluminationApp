using System.Collections;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour {

    Vector2 PrevPositionInMetrics;
    float totalMoveDistance;
    bool isFirstTime = true;

    float SpeedPerHour;
    [SerializeField, Range(0, 60)]
    float WalkingSpeedPerHour;
    [SerializeField,Range(0,60)]
    float RunningSpeedPerHour;
    [SerializeField]
    float waitsecond;
    public float TotalMoveDistance
    {
        get
        {
            return totalMoveDistance;
        }
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
            PrevPositionInMetrics = new Vector2(ref_locationCoordination.GetLongitude, ref_locationCoordination.GetLatitude);
            isFirstTime = false;
        }
        else
        {
            Vector2 a = new Vector2(ref_locationCoordination.GetLongitude, ref_locationCoordination.GetLatitude);
            Vector2 b = new Vector2(PrevPositionInMetrics.x, PrevPositionInMetrics.y);
            float moveDistance = long_lati_calculator.GetInstance.CalculateLetiAndLongDistanceOfAtoB(a, b);
            SpeedPerHour = moveDistance * (3600 / waitsecond);
            if (SpeedPerHour >= WalkingSpeedPerHour && SpeedPerHour < RunningSpeedPerHour) totalMoveDistance += moveDistance;
            PrevPositionInMetrics = new Vector2(a.x, a.y);
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
