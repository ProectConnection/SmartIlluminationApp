using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GoogleMapDrawer))]
public class MapSpotVisilizer : MonoBehaviour {
    SpotManager ref_SpotManager;
    GoogleMapDrawer ref_GoogleMapDrawer;
    Locator ref_Locator;
    [SerializeField]
    Vector2 MapMeterPerOneUnit;
    public Vector2 mapMeterPerOneUnit
    {
        get
        {
            return MapMeterPerOneUnit;
        }
    }
    // Use this for initialization
    void Start () {
        
        ref_SpotManager = GameObject.FindGameObjectWithTag("SpotManager").GetComponent<SpotManager>();
        ref_GoogleMapDrawer = GameObject.FindGameObjectWithTag("MapDrawer").GetComponent<GoogleMapDrawer>();
        ref_Locator = GameObject.FindGameObjectWithTag("Locator").GetComponent<Locator>();
        
        ref_Locator.OnLocationUpdate.AddListener(StartSpotLocationUpdate);
        ref_SpotManager.ChangeSpotVisiblity(true);
    }

    public void StartSpotLocationUpdate()
    {
        StartCoroutine(SpotLocationUpdate());
    }

    IEnumerator SpotLocationUpdate()
    {
        ref_SpotManager.ChangeSpotParentTransform(transform);
        long_lati_calculator calcInstance = long_lati_calculator.GetInstance;
        foreach (SpotClass spotClass in ref_SpotManager.ref_SpotClasses)
        {
            //スポットと現在位置の距離を計測
            float distance = calcInstance.CalculateLetiAndLongDistanceOfAtoB(spotClass.ThisSpotData.GetSpotCoordInVec2,
                                                            ref_Locator.locationCoordination.GetLocationCoordInVec2);

            spotClass.isSpotNearPlayer = distance <= spotClass.ThisSpotData.spotActivateDistance;
            //現在位置が0,0で表示されている前提で移動する
            Vector2 Diff = calcInstance.CalculateLetiAndLongDifferenceOfAtoB(
                spotClass.ThisSpotData.GetSpotCoordInVec2,
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
            Vector3 SpotPosition = new Vector3((Diff.x / (MapMeterPerOneUnit.x / ref_GoogleMapDrawer.mapScale)) * ref_GoogleMapDrawer.transform.localScale.x,
                                               spotClass.thisTransform.position.y,
                                               (Diff.y / (MapMeterPerOneUnit.y / ref_GoogleMapDrawer.mapScale)) * ref_GoogleMapDrawer.transform.localScale.z
                                               );
            Debug.Log(spotClass.name + "Diffs" + Diff.x + "," + Diff.y);
            spotClass.ChangeScaleSpotRange();
            spotClass.SetWorldPosition(SpotPosition);
            yield return new WaitForFixedUpdate();
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
