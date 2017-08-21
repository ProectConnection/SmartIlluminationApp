using UnityEngine;

public class DistanceTxt : MeterUITxt{
    [SerializeField]
    DistanceCalculator ref_distanceCalculator;

    private void Update()
    {
        TextUI.text = Metrics.ToString("f3");
    }

    public override void GetLocationCoordinationValue()
    {
        Metrics = ref_distanceCalculator.TotalMoveDistance;
        
    }
}
