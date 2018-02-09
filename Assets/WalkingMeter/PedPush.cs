using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedPush : MonoBehaviour
{
    //[SerializeField]
    //List<NotiID> Pednoti = new List<NotiID>();

    //public List<NotiID> pednoti
    //{
    //    get { return Pednoti; }
    //    set { Pednoti = value; }
    //}

    [SerializeField]
    Sprite deb_BGImage;

    NoticeManager ref_NoticeManager;
    DataSaver ref_DataSaver;

    // 必要達成歩数
    int[] Noticount = { 2000, 3000, 4000, 5000 };
    int i = 0;

    // スプライトの登録

    //public Sprite Pedmeter_chapter1, Pedmeter_chapter2, Pedmeter_chapter3, Pedmeter_chapter4;


    // Use this for initialization
    void Start()
    {
        // DataSaverから歩数を取得
        ref_DataSaver = DataSaver.GetDataSaver();
        //StartCoroutine(LoadToDataSaver());

        ref_NoticeManager = GameObject.Find("NotiManager").GetComponent<NoticeManager>();

    }

    void Update()
    {
        if (ref_DataSaver.Pedocount <= Noticount[3])
        {
            checkPedcount();
        }
    }

    //public IEnumerator LoadToDataSaver()
    //{
    //    DataSaver ref_dataSaver = DataSaver.GetDataSaver();
    //    Pednoti = ref_dataSaver.Pednoti;
    //    yield return null;
    //}

    //public IEnumerator SaveToDataSaver()
    //{
    //    DataSaver ref_dataSaver = DataSaver.GetDataSaver();
    //    ref_dataSaver.SetDataPedNoti(pednoti);
    //    yield return null;
    //}


    void checkPedcount()
    {
        if (ref_DataSaver.Pedocount >= Noticount[i])
        {

            ref_NoticeManager.CreateNotice(deb_BGImage, Noticount[i] + "歩達成！");
           
            //StartCoroutine(SaveToDataSaver());

            i++;

        }
    }

}