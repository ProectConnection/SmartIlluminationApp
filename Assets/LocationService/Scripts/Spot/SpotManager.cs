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
    Locator ref_Locator;
    List<SpotClass> ref_SpotClasses;
    //SpotClass[] ref_SpotClasses;

    private void Start()
    {
        ref_SpotClasses = new List<SpotClass>();
        ref_Locator = GameObject.FindGameObjectWithTag("Locator").GetComponent<Locator>();
        //CreateSpotClass("Yokohama Digital Arts");
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
        ref_SpotClasses.Add(Instantiate(SpotPrefab).GetComponent<SpotClass>());
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
            Debug.Log("spotClass" + spotClass);
            //現在位置が0,0で表示されている前提で移動する
            Vector2 Diff = long_lati_calculator.GetInstance.CalculateLetiAndLongDifferenceOfAtoB(
                spotClass.ThisSpotData.GetSpotCoordInVec2,
                ref_Locator.locationCoordination.GetLocationCoordInVec2);

            Vector3 SpotPosition = new Vector3(Diff.x / LongDegPerWorldSpace, 1,Diff.y / LetiDegPerWorldSpace);
            spotClass.SetWorldPosition(SpotPosition);
            yield return new WaitForFixedUpdate();
        }

        yield return null;
        
    }
}
