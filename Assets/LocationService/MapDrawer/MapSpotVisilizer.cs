using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GoogleMapDrawer))]
public class MapSpotVisilizer : MonoBehaviour {
    SpotManager ref_SpotManager;
    GoogleMapDrawer ref_GoogleMapDrawer;
    Locator ref_Locator;
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
        ref_GoogleMapDrawer = GameObject.FindGameObjectWithTag("MapDrawer").GetComponent<GoogleMapDrawer>();
        ref_Locator = GameObject.FindGameObjectWithTag("Locator").GetComponent<Locator>();
        
        ref_Locator.OnLocationUpdate.AddListener(StartSpotLocationUpdate);

        EquatorArcLength = 2 * System.Math.PI * long_lati_calculator.Equator;
        RadiusArcLength = 2 * System.Math.PI * long_lati_calculator.EarthRadius;
        RefrashMapUnit();
    }
    public void RefrashMapUnit()
    {

        MapMeterPerOneUnit.x = (float)(EquatorArcLength / (System.Math.Pow(2, ((ref_GoogleMapDrawer.mapSize + 1) )) * transform.lossyScale.x * MapZoomMagicNumber.x));
        MapMeterPerOneUnit.y = (float)(RadiusArcLength / (System.Math.Pow(2, ((ref_GoogleMapDrawer.mapSize + 1)  )) * transform.lossyScale.z * MapZoomMagicNumber.y));
        //MapMeterPerOneUnit.x = (float)(EquatorArcLength /((ref_GoogleMapDrawer.mapSize + 1) * ref_GoogleMapDrawer.mapScale * transform.lossyScale.x));
        //MapMeterPerOneUnit.y = (float)(RadiusArcLength / ((ref_GoogleMapDrawer.mapSize + 1) * ref_GoogleMapDrawer.mapScale * transform.lossyScale.z));
    }
    public void StartSpotLocationUpdate()
    {
        StartCoroutine(SpotLocationUpdate());
    }

    IEnumerator SpotLocationUpdate()
    {
        bool IsAnyNearSpotExist = false;
        ref_SpotManager.ChangeSpotParentTransform(transform);
        long_lati_calculator calcInstance = long_lati_calculator.GetInstance;
        RefrashMapUnit();
        foreach (SpotClass spotClass in ref_SpotManager.ref_SpotClasses)
        {
            spotClass.visible = true;
            //スポットと現在位置の距離を計測
            double distance = calcInstance.CalculateLetiAndLongDistanceOfAtoB(spotClass.ThisSpotData.GetSpotCoordInDVec2,
                                                            ref_Locator.locationCoordination.GetLocationCoordInVec2);
            //近接しているスポットの更新処理
            spotClass.isSpotNearPlayer = distance <= spotClass.ThisSpotData.spotActivateDistance;
            if (spotClass.isSpotNearPlayer)
            {
                ref_SpotManager.nearestSpotData = spotClass.ThisSpotData;
                IsAnyNearSpotExist = true;
            }
            Debug.Log(spotClass.name + "Dist:" + distance);
            //現在位置が0,0で表示されている前提で移動する
            DVector2 Diff = calcInstance.CalculateLetiAndLongDifferenceOfAtoB(
                spotClass.ThisSpotData.GetSpotCoordInDVec2,
                ref_Locator.locationCoordination.GetLocationCoordInVec2);
            /*
             * 変化するもの
             mapズーム率
             画像解像度
             Unity上のスケール
             1unitがmap上での何mか？ / 17レベルを基準にしたmapzoomの相対値
            求めるもの
            Unity座標１当たりがmapでは何メートルなのか
             */

            //Vector3 SpotPosition = new Vector3(Diff.x / ((float)(2.0 * Mathf.PI * instance.Equator ) / (zoomlevel * scale)), AttacedTransform.position.y, Diff.y / ((float)( (2.0 * Mathf.PI * instance.earthRadius )/ (zoomlevel * scale))));
            Vector3 SpotPosition = new Vector3((float)(-(Diff.x / (MapMeterPerOneUnit.x ) )),
                                               spotClass.thisTransform.position.y,
                                               (float)(-(Diff.y / (MapMeterPerOneUnit.y ) ))
                                               );
            Debug.Log(spotClass.name + "Diffs" + Diff.x + "," + Diff.y);
            spotClass.ChangeScaleSpotRange();
            spotClass.SetWorldPosition(SpotPosition);
            yield return new WaitForFixedUpdate();
        }
        if (!IsAnyNearSpotExist)
        {
            ref_SpotManager.nearestSpotData = null;
        }
        yield return null;

    }

    private void OnDestroy()
    {
        ref_Locator.OnLocationUpdate.RemoveListener(this.StartSpotLocationUpdate);
        ref_SpotManager.ChangeSpotParentTransform(ref_SpotManager.transform);
        ref_SpotManager.ChangeSpotVisiblity(false);
    }
}
