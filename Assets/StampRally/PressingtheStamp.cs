using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PressingtheStamp : MonoBehaviour {


    [SerializeField]
    Image TapMark;


    public Image StampMark;
    int count = 0;



    // Use this for initialization
    void Start () {

        EventTrigger trigger = TapMark.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();


        //イベント検出
        entry.eventID = EventTriggerType.PointerClick;
        //コールバック登録
        entry.callback.AddListener(Clicked);
        //EventTriggerに追加
        trigger.triggers.Add(entry);


        StampMark = GameObject.Find("Canvas/StampMark").GetComponent<Image>();



	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.A))
        {
            count++;
            Debug.Log(count);
        }


    }


    void Clicked(BaseEventData eventData)
    {


        Debug.Log("(ﾟ∀ﾟ)");
        

        if(count == 5)
        {

            Debug.Log("(*ﾉωﾉ)");

        }





    }


}
