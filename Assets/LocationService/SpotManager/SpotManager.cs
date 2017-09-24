﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotManager : MonoBehaviour {
    
    [SerializeField]
    GameObject SpotPrefab;
    SpotData[] RegistrationSpot;
    [SerializeField]
    string SpotDataResourcePass;
    Locator ref_Locator;
    public List<SpotClass> ref_SpotClasses;
    //SpotClass[] ref_SpotClasses;
    Transform AttacedTransform;
    [SerializeField]
    SpotData NearestSpotData;
    public SpotData nearestSpotData
    {
        get { return NearestSpotData; }
        set { NearestSpotData = value; }
    }
    private void Start()
    {
        AttacedTransform = gameObject.transform;
        ref_SpotClasses = new List<SpotClass>();
        ref_Locator = GameObject.FindGameObjectWithTag("Locator").GetComponent<Locator>();
        
        RegistrationSpot = Resources.LoadAll<SpotData>(("SpotDatas/" + SpotDataResourcePass));
        foreach (var ref_spotData in RegistrationSpot)
        {
            CreateSpotClass(ref_spotData.SpotName);
        }
        
        
    }

    public void ChangeSpotParentTransform(Transform NextParent)
    {
        foreach(SpotClass ref_spotClass in ref_SpotClasses)
        {
            if (ref_spotClass.thisTransform == null) continue;
            ref_spotClass.thisTransform.SetParent(NextParent);
        }
    }

    public void ChangeSpotVisiblity(bool NextVisiblity)
    {
        foreach(SpotClass ref_spotClass in ref_SpotClasses)
        {
            ref_spotClass.visible = NextVisiblity;
        }
    }

    void CreateSpotClass(string SpotID)
    {
        GameObject instansiateGameObject = Instantiate(SpotPrefab);
        instansiateGameObject.name = "Spot(" + SpotID + ")";
        ref_SpotClasses.Add(instansiateGameObject.GetComponent<SpotClass>());
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

    
}
