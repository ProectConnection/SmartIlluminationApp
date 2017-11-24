using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class PedPush : MonoBehaviour
    {
    int Step;
    DataSaver ref_DataSaver;
    int[] FramePush = { 2000, 3000, 4000, 5000 }; 
        

        // Use this for initialization
        void Start()
        {

        ref_DataSaver = DataSaver.GetDataSaver();
        checkPedcount();

    }

        // Update is called once per frame
        void Update()
        {

        // テスト
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Step += 1000;
            Debug.Log(Step);
            checkPedcount();
        }
    }

    void checkPedcount()
    {
        for (int i = 0; i < FramePush.Length; i++) {
            // if (ref_DataSaver.Pedocount >= stepcount[i])
            if (Step >= FramePush[i])
            {
                Debug.Log(FramePush[i] + "歩達成!");
            }
        }
    }
    
}
