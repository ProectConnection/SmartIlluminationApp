using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour {

    [SerializeField]
    Image ClickImage;


    //public GameObject[] Stamp = new GameObject[6];

    
    public GameObject f;
    public GameObject s;
    public GameObject t;
    public GameObject fo;
    public GameObject fi;
    public GameObject si;


    GameObject SpotStamp;

    private int IventCount = 0;


    bool Stamp1 = false;
    bool Stamp2 = false;


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

        
        
        f.SetActive(false);
        s.SetActive(false);
        t.SetActive(false);
        fo.SetActive(false);
        fi.SetActive(false);
        si.SetActive(false);
        


        OK.SetActive(false);


        SpotStamp = GameObject.FindGameObjectWithTag("SpotManager");
        SpotData neareSpotData = SpotStamp.GetComponent<SpotManager>().nearestSpotData;



        if(neareSpotData.stampId == StampID.YDAStamp1)
        {

            Stamp1 = true;

        }
        if (neareSpotData.stampId == StampID.YDAStamp2)
        {

            Stamp2 = true;

        }



    }

    // Update is called once per frame
    void Update () {





        if(SpotStamp != null)
        {

            SpotAreaIN();

        }
        

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
        //Debug.Log(IventCount);
        //IventCount++;

        if (Stamp1 == true)
        {
            f.SetActive(true);
            
        }
        if (Stamp2 == true)
        {
            s.SetActive(true);

        }






    }


    
    



}
