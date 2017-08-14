using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotManager : MonoBehaviour {
    [SerializeField, Range(0, Mathf.Infinity)]
    float LongDegPerWorldSpace;
    [SerializeField,Range(0,Mathf.Infinity)]
    float LetiDegPerWorldSpace;
    [SerializeField]
    GameObject SpotPrefab;
    [SerializeField]
    SpotData[] RegistrationSpot;
    [SerializeField]
    string SpotDataResourcePass;
    Locator ref_Locator;
    List<SpotClass> ref_SpotClasses;
    //SpotClass[] ref_SpotClasses;
    Transform AttacedTransform;
    private void Start()
    {
        AttacedTransform = gameObject.transform;
        ref_SpotClasses = new List<SpotClass>();
        ref_Locator = GameObject.FindGameObjectWithTag("Locator").GetComponent<Locator>();
        //CreateSpotClass("Yokohama Digital Arts");
        
        RegistrationSpot = Resources.LoadAll<SpotData>(("SpotDatas/" + SpotDataResourcePass));
        Debug.Log(RegistrationSpot);
        foreach (var ref_spotData in RegistrationSpot)
        {
            CreateSpotClass(ref_spotData.SpotName);
        }
        
        
    }

    public void StartSpotLocationUpdate()
    {
        StartCoroutine(SpotLocationUpdate());
    }


    void CreateSpotClass(string SpotID)
    {
        ref_SpotClasses.Add(Instantiate(SpotPrefab,AttacedTransform).GetComponent<SpotClass>());
        ref_SpotClasses[ref_SpotClasses.Count - 1].SetThisSpotData(FindSpotData(SpotID));
    }

    SpotClass FindDeactivatedSpotClasses()
    {
        foreach (SpotClass ref_SpotClass in ref_SpotClasses)
        {
            if (ref_SpotClass.isActivate == false) return ref_SpotClass;
        }

        return null;
    }

    SpotData FindSpotData(string SpotID)
    {
        try
        {
            foreach (var spotdata in RegistrationSpot)
            {
                if (spotdata.SpotName == SpotID) return spotdata;
            }
            throw new KeyNotFoundException();
        }
        catch(KeyNotFoundException)
        {
            Debug.LogError("error:SpotIDに一致するSpotDataが見つかりません。\nSpotID = " + SpotID);
            return null;
        }
        
    }

    IEnumerator SpotLocationUpdate()
    {
        foreach(SpotClass spotClass in ref_SpotClasses)
        {
            //現在位置が0,0で表示されている前提で移動する
            Vector2 Diff = long_lati_calculator.GetInstance.CalculateLetiAndLongDifferenceOfAtoB(
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
            long_lati_calculator instance = long_lati_calculator.GetInstance;
            int zoomlevel = 17;
            int scale = 2;

            
            //instance.EarthRadius / zoomlevel

            Vector3 SpotPosition = new Vector3(Diff.x / ((float)(2.0 * Mathf.PI * instance.Equator )/ (zoomlevel * scale)), AttacedTransform.position.y, Diff.y / ((float)( (2.0 * Mathf.PI * instance.earthRadius )/ (zoomlevel * scale))));
            spotClass.SetWorldPosition(SpotPosition);
            yield return new WaitForFixedUpdate();
        }

        yield return null;
        
    }
}
