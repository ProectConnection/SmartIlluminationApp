using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GoogleMapManager))]
public class MapSpotVisilizer : MonoBehaviour {
    SpotManager ref_SpotManager;
    GoogleMapManager ref_GoogleMapManager;
    Locator ref_Locator;
    LocationCoordination StandardInitialZeroCoord;
    Transform ref_PlayerTransform;
    bool isStandardInitialZeroCoordHasChanged;
    [SerializeField]
    Vector2 MapZoomMagicNumber;
    [SerializeField]
    Vector2 MapMeterPerOneUnit;
    public Vector2 mapMeterPerOneUnit
    {
        get
        {
            return MapMeterPerOneUnit;
        }
    }
    public double EquatorArcLength;
    public double RadiusArcLength;
    // Use this for initialization
    void Start () {
        
        ref_SpotManager = GameObject.FindGameObjectWithTag("SpotManager").GetComponent<SpotManager>();
        //ref_GoogleMapDrawer = GameObject.FindGameObjectWithTag("CentMapDrawer").GetComponent<GoogleMapDrawer>();
        ref_GoogleMapManager = GameObject.FindGameObjectWithTag("GoogleMapManager").GetComponent<GoogleMapManager>();
        ref_Locator = GameObject.FindGameObjectWithTag("Locator").GetComponent<Locator>();
        ref_PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        ref_Locator.OnLocationUpdate.AddListener(StartSpotLocationUpdate);

        EquatorArcLength = 2 * System.Math.PI * long_lati_calculator.Equator;
        RadiusArcLength = 2 * System.Math.PI * long_lati_calculator.EarthRadius;
        RefrashMapUnit();
    }
    public void RefrashMapUnit()
    {

        MapMeterPerOneUnit.x = (float)(EquatorArcLength / (System.Math.Pow(2, ((ref_GoogleMapManager.ZoomLevel+ 1) )) * transform.lossyScale.x * MapZoomMagicNumber.x));
        MapMeterPerOneUnit.y = (float)(RadiusArcLength / (System.Math.Pow(2, ((ref_GoogleMapManager.ZoomLevel + 1)  )) * transform.lossyScale.z * MapZoomMagicNumber.y));
        //MapMeterPerOneUnit.x = (float)(EquatorArcLength /((ref_GoogleMapDrawer.mapSize + 1) * ref_GoogleMapDrawer.mapScale * transform.lossyScale.x));
        //MapMeterPerOneUnit.y = (float)(RadiusArcLength / ((ref_GoogleMapDrawer.mapSize + 1) * ref_GoogleMapDrawer.mapScale * transform.lossyScale.z));
    }
    public void StartSpotLocationUpdate()
    {
        StartCoroutine(SpotLocationUpdate());
    }

    public void SetStandardInitialZeroCoord(LocationCoordination newCoord)
    {
        StandardInitialZeroCoord = newCoord;

        if (isStandardInitialZeroCoordHasChanged) Debug.LogWarning("MapSpotVisilizerの基準点が複数回変更されています。\n予期しない動作が起こる可能性があります。");
        isStandardInitialZeroCoordHasChanged = true;
    }

    IEnumerator SpotLocationUpdate()
    {
        bool IsAnyNearSpotExist = false;
        double nearestDistance = -1f;
        ref_SpotManager.ChangeSpotParentTransform(transform);
        long_lati_calculator calcInstance = long_lati_calculator.GetInstance;
        RefrashMapUnit();

        Vector3 PlayerNextPos = CalculateByMapDistanceLocationAndReturnVec3(ref_PlayerTransform, ref_Locator.locationCoordination);
        ref_PlayerTransform.position = PlayerNextPos;
        foreach (SpotClass spotClass in ref_SpotManager.ref_SpotClasses)
        {
            spotClass.visible = true;
            //スポットと現在位置の距離を計測
            double distance = calcInstance.CalculateLetiAndLongDistanceOfAtoB(spotClass.ThisSpotData.GetSpotCoordInDVec2,
                                                            StandardInitialZeroCoord.GetLocationCoordInVec2);
            //近接しているスポットの更新処理
            spotClass.isSpotNearPlayer = distance <= spotClass.ThisSpotData.spotActivateDistance;
            if (spotClass.isSpotNearPlayer)
            {
                IsAnyNearSpotExist = true;
                bool isNearestSpot = (nearestDistance < 0.0f) || (nearestDistance > distance);
                if (isNearestSpot)
                {
                    ref_SpotManager.nearestSpotData = spotClass.ThisSpotData;
                    nearestDistance = distance;
                }
            }
            //マップ上でのスポット移動
            spotClass.ChangeScaleSpotRange();
            Vector3 SpotPosition = CalculateByMapDistanceLocationAndReturnVec3(spotClass.thisTransform, new LocationCoordination(spotClass.ThisSpotData.GetSpotCoordInDVec2));
            spotClass.SetWorldPosition(SpotPosition);
            yield return new WaitForFixedUpdate();
        }
        if (!IsAnyNearSpotExist)
        {
            ref_SpotManager.nearestSpotData = null;
        }
        yield return null;

    }

    Vector3 CalculateByMapDistanceLocationAndReturnVec3(Transform movetarget,LocationCoordination moveTargetLocationCoord)
    {
        long_lati_calculator calcInstance = long_lati_calculator.GetInstance;

        //現在位置が0,0で表示されている前提で移動する
        DVector2 Diff = calcInstance.CalculateLetiAndLongDifferenceOfAtoB(
            moveTargetLocationCoord.GetLocationCoordInVec2,
            StandardInitialZeroCoord.GetLocationCoordInVec2);

        Vector3 movePosition = new Vector3((float)(-(Diff.x / (MapMeterPerOneUnit.x))),
                                                   movetarget.position.y,
                                                   (float)(-(Diff.y / (MapMeterPerOneUnit.y)))
                                                   );

        return movePosition;
    }

    private void OnDestroy()
    {
        ref_Locator.OnLocationUpdate.RemoveListener(this.StartSpotLocationUpdate);
        if (ref_SpotManager != null)
        {
            ref_SpotManager.ChangeSpotParentTransform(ref_SpotManager.transform);
            ref_SpotManager.ChangeSpotVisiblity(false);
        }
    }
}
