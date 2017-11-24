using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DebugConsole
{
    public class DebugFlameButton : MonoBehaviour
    {
        [SerializeField]
        GameObject FlamePresserGO;
        DataSaver ref_DataSaver;
        int reversePedcount;  //返す歩数
        DebugConsole.DebugFlamePresser FlamePresser;

        // Use this for initialization
        void Start()
        {
            FlamePresser = FlamePresserGO.GetComponent<DebugConsole.DebugFlamePresser>();
            ref_DataSaver = DataSaver.GetDataSaver();
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(CheatStampPress);
        }

        void CheatStampPress()
        {
            reversePedcount = FlamePresser.gocountList;
            ref_DataSaver.AddInitialPedocount(reversePedcount);
            Debug.Log("ボタンで呼び出した数値" + reversePedcount);
        }
    }
}