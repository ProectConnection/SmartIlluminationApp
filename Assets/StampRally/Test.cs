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


    private int IventCount = 0;


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

        OK.SetActive(true);




    }

    // Update is called once per frame
    void Update () {



        /*if (Input.GetKeyDown(KeyCode.A))
        {

            OK.SetActive(true);

        }
        */

    }




    //スポットのエリアに入ったら
    void SpotAreaIN()
    {

       

    }

    void SpotAreaOUT()
    {

       
            OK.SetActive(false);

        

    }






    public void Clicked(BaseEventData eventData)
    {
        Debug.Log(IventCount);
        IventCount++;


        if (IventCount == 1)
        {
            f.SetActive(true);
            SpotAreaOUT();
        }
        if (IventCount == 2)
        {
            s.SetActive(true);
            SpotAreaOUT();
        }
        if (IventCount == 3)
        {
            t.SetActive(true);
            SpotAreaOUT();
        }
        if (IventCount == 4)
        {
            fo.SetActive(true);
            SpotAreaOUT();
        }
        if (IventCount == 5)
        {
            fi.SetActive(true);
            SpotAreaOUT();
        }
        if (IventCount == 6)
        {
            si.SetActive(true);
            SpotAreaOUT();
        }


        PlayerPrefs.Save();



    }


    
    



}
