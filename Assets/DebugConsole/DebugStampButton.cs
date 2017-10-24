using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DebugConsole{
    public class DebugStampButton : MonoBehaviour {
        [SerializeField]
        GameObject stampPresserGO;
        StampData ref_stampData;
        DebugConsole.DebugStampPresser stampPresser;

        // Use this for initialization
        void Start() {
            stampPresser = stampPresserGO.GetComponent<DebugConsole.DebugStampPresser>();
            ref_stampData = StampData.GetStampData;

            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(CheatStampPress);
        }

        void CheatStampPress()
        {
            ref_stampData.StampPress(stampPresser.cheatStampId);
            Debug.Log("Cheat Stamp Press On" + stampPresser.cheatStampId);
        }
    }
}
