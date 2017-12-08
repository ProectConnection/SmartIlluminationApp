using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour {

    [SerializeField]
    Image ClickImage;
    [SerializeField]
    GameObject[] StampPosition;

    [SerializeField]
    GameObject[] StampGameObject;

    GameObject SpotStamp;

    private int IventCount = 0;

    StampData Ref_stampData;

    public GameObject OK;
    [SerializeField]
    Image GoalImage;

    // Use this for initialization
    void Start () {

        List<StampID> StampList = new List<StampID>();
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
            if (!(neareSpotData.spotType <= SpotType.Photo))
            {
                if (Ref_stampData.IsPressedStampById(neareSpotData.stampId)) SpotAreaOUT();
                else { SpotAreaIN(); }
            }
            else { SpotAreaOUT(); }
        }
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
        int i;
        i = Ref_stampData.pressedStamp.Count;
        if (i <= 6){
            OK.transform.position = StampPosition[i].transform.position;
            OK.SetActive(true);
        }
    }

    void SpotAreaOUT()
    {

      OK.SetActive(false);

    }

    public void Clicked(BaseEventData eventData)
    {
        Debug.Log("Clicked");
        Ref_stampData.StampPress();
        if (Ref_stampData.pressedStamp.Count >= StampGameObject.Length)
        {
            ShowGoalImage();
        }
        UpdateStampCardView();
        SpotAreaOUT();
    }

    void ShowGoalImage()
    {
        GoalImage.enabled = true;
        StartCoroutine(GoalImageFadeIn());
    }

    IEnumerator GoalImageFadeIn()
    {
        Color newColor = Color.HSVToRGB(0, 0, 255);
        newColor.a = 0;
        
        while (newColor.a < 1)
        {
            newColor.a += (Time.deltaTime / 3.0f);
            GoalImage.color = newColor;
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
}
