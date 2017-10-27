using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour {

    [SerializeField]
    Image ClickImage;

    [SerializeField]
    GameObject[] StampGameObject;

    GameObject SpotStamp;

    private int IventCount = 0;

    StampData Ref_stampData;

    public GameObject OK;



    // Use this for initialization
    void Start () {


        EventTrigger trigger = ClickImage.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        // なんのイベントを検出するか
        entry.eventID = EventTriggerType.PointerClick;
        // コールバック登録
        entry.callback.AddListener(Clicked);

        // EventTriggerに追加
        trigger.triggers.Add(entry);

        
        


        //OK.SetActive(false);

        Ref_stampData = StampData.GetStampData;
        Debug.Log(Ref_stampData);
        SpotStamp = GameObject.FindGameObjectWithTag("SpotManager");
        SpotData neareSpotData = SpotStamp.GetComponent<SpotManager>().nearestSpotData;
        if (neareSpotData != null)
        {
            if (neareSpotData.spotType <= SpotType.Photo || Ref_stampData.IsPressedStampById(neareSpotData.stampId)) SpotAreaOUT();
        }
        else { SpotAreaOUT(); }

        UpdateStampCardView();
    }

    public void UpdateStampCardView()
    {
        {
            int i = 0;
            for (int j = 0; j < StampGameObject.Length; j++)
            {
                if(i < Ref_stampData.pressedStamp.Count)
                {
                    StampGameObject[j].SetActive(true);
                    i++;
                }
                else StampGameObject[j].SetActive(false);
            }
        }

    }

    //public void StampPress()
    //{
    //    SpotData neareSpotData = SpotStamp.GetComponent<SpotManager>().nearestSpotData;


    //    if (!IsPressedStampById(neareSpotData.stampId))
    //    {
    //        Debug.Log("pressedStamp.Count" + pressedStamp.Count);
    //        pressedStamp.Add(neareSpotData.stampId);
    //    }

    //    UpdateStampCardView();
    //}

    // Update is called once per frame
    void Update () {
        //if(SpotStamp != null)
        //{

        //    SpotAreaIN();

        //}
        

    }




    //スポットのエリアに入ったら
    void SpotAreaIN()
    {

       OK.SetActive(true);
      
    }

    void SpotAreaOUT()
    {

 
      OK.SetActive(false);
        

    }

    public void Clicked(BaseEventData eventData)
    {
        Debug.Log("Clicked");
        Ref_stampData.StampPress();
        UpdateStampCardView();
        SpotAreaOUT();
    }
}
