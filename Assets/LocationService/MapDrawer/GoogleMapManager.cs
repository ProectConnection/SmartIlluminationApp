using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleMapManager : MonoBehaviour {
    [SerializeField]
    uint zoomlevel = 1;
    public uint ZoomLevel
    {
        get { return zoomlevel; }
        set { zoomlevel = value; }
    }
    [SerializeField]
    GameObject Prefab_GoogleMapDrawer;
    Locator ref_locator;
    GoogleMapPictureCoordination nowLocationMapCoord;
    List<GoogleMapDrawer> ref_googleMapDrawers;
    Transform thisTransform;
    [SerializeField]
    Transform TargetTransformStandardMapAddLoad;
    MapSpotVisilizer ref_MapSpotVisilizer;
    LocationCoordination InitialLocationCoordinate;
    bool isInitialLocationUpdate = true;
    private void Start()
    {
        PrefabCheck();
        thisTransform = GetComponent<Transform>();
        ref_googleMapDrawers = new List<GoogleMapDrawer>();
        ref_locator = GameObject.FindGameObjectWithTag("Locator").GetComponent<Locator>();
        ref_locator.OnLocationUpdate.AddListener(OnLocatorHasUpdate);
        ref_MapSpotVisilizer = GetComponent<MapSpotVisilizer>();
        ////テスト用のコード
        ////すでに配置されているGoogleMapDrawerを読み込み、配列に格納する
        //GoogleMapDrawer[] tGMDs = transform.GetComponentsInChildren<GoogleMapDrawer>();
        
        //if(tGMDs.Length > 0)
        //{
        //    GoogleMapPictureCoordination nextMapLoc = GoogleMapPictureCoordination.CalculateMapCoordinationFromLetiAndLong(ref_locator.locationCoordination, zoomlevel);
        //    Debug.Log(GoogleMapPictureCoordination.CalculateLetiAndLongFromMapCoordination(nextMapLoc));
        //    tGMDs[0].SetLocationCoordinate(GoogleMapPictureCoordination.CalculateLetiAndLongFromMapCoordination(nextMapLoc));
        //}
        //if (tGMDs != null) ref_googleMapDrawers.AddRange(tGMDs);
        
    }

    public Locator ref_Locator
    {
        get { return ref_locator; }
        set { ref_locator = value; }
    }

    void OnLocatorHasUpdate()
    {
        CalculateMapCoordFromNowLocation();
    }
    void CalculateMapCoordFromNowLocation()
    {
        if (isInitialLocationUpdate)
        {
            //チェックポイント0,0の基準点の設定・GoogleMapDrawerの作成
            InitialLocationCoordinate = ref_locator.locationCoordination;

            GoogleMapDrawer ref_ILCGMD = CreateGoogleMapDrawer(InitialLocationCoordinate);
            ref_ILCGMD.mapSize = zoomlevel;
            ref_ILCGMD.BuildMap();
            ref_MapSpotVisilizer.SetStandardInitialZeroCoord(ref_ILCGMD.Calculator);
            
            isInitialLocationUpdate = false;
        }
        nowLocationMapCoord = CalculateMapCoordinationFromLetiAndLong(ref_locator.locationCoordination);
        Debug.Log(nowLocationMapCoord);
        foreach (GoogleMapDrawer ref_GMD in ref_googleMapDrawers)
        {
            ref_GMD.mapSize = zoomlevel;
            ref_GMD.BuildMap();
        }
    }

    GoogleMapDrawer CreateGoogleMapDrawer()
    {
        GameObject instanceObject = Instantiate<GameObject>(Prefab_GoogleMapDrawer, thisTransform);
        instanceObject.transform.rotation = Quaternion.Euler(0, -180, 0);
        ref_googleMapDrawers.Add(instanceObject.GetComponent<GoogleMapDrawer>());
        
        return ref_googleMapDrawers[ref_googleMapDrawers.Count - 1];
    }

    GoogleMapDrawer CreateGoogleMapDrawer(LocationCoordination coord)
    {
        GoogleMapDrawer ref_GMDsLast = CreateGoogleMapDrawer();
        ref_GMDsLast.SetLocationCoordinate(coord);
        return ref_GMDsLast;
    }

    public GoogleMapPictureCoordination CalculateMapCoordinationFromLetiAndLong(LocationCoordination coordination)
    {
        return GoogleMapPictureCoordination.CalculateMapCoordinationFromLetiAndLong(coordination,this.zoomlevel);
    }

    void PrefabCheck()
    {
        try
        {
            if (Prefab_GoogleMapDrawer == null || Prefab_GoogleMapDrawer.GetComponent<GoogleMapDrawer>() == null) throw new IncorrectPrefabException();
        }
        catch(IncorrectPrefabException)
        {
            Debug.LogError("GoogleMapDrawerのプレハブがセットされていません。");
        }
        
    }
}

class IncorrectPrefabException:System.Exception{
    
};

