using System.Collections.Generic;
using UnityEngine;

public class SpotManager : MonoBehaviour {
    
    [SerializeField]
    GameObject SpotPrefab;
    List<SpotData> RegistrationSpot;
    [SerializeField]
    string[] SpotDataResourcePasses;
    public List<SpotClass> ref_SpotClasses;
    [SerializeField]
    SpotData NearestSpotData;
    [SerializeField]
    Texture[] SpotMarkTextures;
    public SpotData nearestSpotData
    {
        get { return NearestSpotData; }
        set { NearestSpotData = value; }
    }
    private void Start()
    {
        ref_SpotClasses = new List<SpotClass>();
        RegistrationSpot = new List<SpotData>();
        foreach(string SpotDataResourcePass in SpotDataResourcePasses)
        {
            RegistrationSpot.AddRange(Resources.LoadAll<SpotData>(("SpotDatas/" + SpotDataResourcePass)));

        }
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
        
        SpotClass ref_InstansiatespotClass = instansiateGameObject.GetComponent<SpotClass>();
        ref_SpotClasses.Add(ref_InstansiatespotClass);
        ref_InstansiatespotClass.visible = false;
        ref_SpotClasses[ref_SpotClasses.Count - 1].SetThisSpotData(FindSpotData(SpotID));
        Texture spotTypetexture;
        switch (ref_InstansiatespotClass.ThisSpotData.spotType)
        {
            case SpotType.CheckPoint:
            case SpotType.PhotoCheck:
                spotTypetexture = SpotMarkTextures[0];
                break;
            case SpotType.Photo:
                spotTypetexture = SpotMarkTextures[1];
                break;
            default:
                spotTypetexture = null;
                break;
        }
        ref_InstansiatespotClass.thisRenderer.material.SetTexture("_MainTex", spotTypetexture);
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
