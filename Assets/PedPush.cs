using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class PedPush : MonoBehaviour
{
    [SerializeField]
    List<NotiID> Pednoti = new List<NotiID>();

    public List<NotiID> pednoti
    {
        get { return Pednoti; }
        set { Pednoti = value; }
    }

    [SerializeField]
    GameObject Pre_Notice;
    [SerializeField]
    Transform CanvasTransform;
    [SerializeField]
    Sprite deb_constructSprite;
    NoticeManager ref_NoticeManager;
    DataSaver ref_DataSaver;

    // 必要達成歩数
    int[] Noticount = { 3000, 4000, 5000, 6000 };

    // スプライトの登録
    public Sprite notiSprite1, notiSprite2, notiSprite3, notiSprite4;

    // Use this for initialization
    void Start()
    {
        // DataSaverから歩数を取得
        ref_DataSaver = DataSaver.GetDataSaver();
        StartCoroutine(LoadToDataSaver());

        ref_NoticeManager = GameObject.Find("NotiManager").GetComponent<NoticeManager>();
        
    }

    void Update()
    {
        checkPedcount();
    }

    public IEnumerator LoadToDataSaver()
    {
        DataSaver ref_dataSaver = DataSaver.GetDataSaver();
        Pednoti = ref_dataSaver.Pednoti;
        yield return null;
    }

    public IEnumerator SaveToDataSaver()
    {
        DataSaver ref_dataSaver = DataSaver.GetDataSaver();
        ref_dataSaver.SetDataPedNoti(pednoti);
        yield return null;
    }


    void checkPedcount()
    {

        Debug.Log(ref_DataSaver.Pedocount+"aaaa");

        while(ref_DataSaver.Pedocount >= Noticount[3])
        {

            if (ref_DataSaver.Pedocount >= Noticount[3])
            {
                Debug.Log(ref_DataSaver.Pedocount);
                Debug.Log(Noticount[3] + "歩達成!");

                ref_NoticeManager.CreateNotice(deb_constructSprite);
                //pressedStamp.Add(neareSpotData.stampId);
                StartCoroutine(SaveToDataSaver());

            }
            else if (ref_DataSaver.Pedocount >= Noticount[2])
            {
                Debug.Log(ref_DataSaver.Pedocount);
                Debug.Log(Noticount[2] + "歩達成!");

            }
            else if (ref_DataSaver.Pedocount >= Noticount[1])
            {
                Debug.Log(ref_DataSaver.Pedocount);
                Debug.Log(Noticount[1] + "歩達成!");

            }
            else if (ref_DataSaver.Pedocount >= Noticount[0])
            {
                Debug.Log(ref_DataSaver.Pedocount);
                Debug.Log(Noticount[0] + "歩達成!");

            }
           // ref_DataSaver.AddInitialPednoti(Noticount);
            break;
        }

    }

}