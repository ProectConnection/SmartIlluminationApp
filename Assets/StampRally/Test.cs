using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour {

    [SerializeField]
    Image ClickImage;

    
    
    public GameObject f;
    public GameObject s;
    public GameObject t;
    //public GameObject fo;


    public int IventCount = 0;
    


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
       // fo.SetActive(false);

        


    }
	
	// Update is called once per frame
	void Update () {

        


       

    }


    public void Clicked(BaseEventData eventData)
    {
        Debug.Log(IventCount);
        IventCount++;


        if (IventCount == 1)
        {
            f.SetActive(true);
        }
        if (IventCount == 2)
        {
            s.SetActive(true);
        }
        if (IventCount == 3)
        {
            t.SetActive(true);
        }

    }

}
