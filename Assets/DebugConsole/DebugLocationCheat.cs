using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLocationCheat : DebugDropDownButtonBase{
    
    SpotManager ref_SpotManager;

    private void ReloadLocationCheatDropDown()
    {
        GameObject ref_SpotManagerGO = GameObject.FindGameObjectWithTag("SpotManager");
        //ドロップダウンリストをスポットマネージャ内のスポットデータに同期
        if (ref_SpotManagerGO)
        {
            ref_SpotManager = ref_SpotManagerGO.GetComponent<SpotManager>();
            List<UnityEngine.UI.Dropdown.OptionData> optionals = new List<UnityEngine.UI.Dropdown.OptionData>();
            foreach (SpotData tsd in ref_SpotManager.registrationSpots)
            {
                optionals.Add(new UnityEngine.UI.Dropdown.OptionData(tsd.SpotName));
            }
            AttachedDropDownList.options = optionals;
        }
    }

    private void OnGUI()
    {
        ReloadLocationCheatDropDown();
    }

    public override void OnClick()
    {
        ref_SpotManager.ActivateCheatSpotData(ref_SpotManager.registrationSpots[AttachedDropDownList.value]);
    }
}
