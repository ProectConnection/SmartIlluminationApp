using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuBar : MonoBehaviour {


    [SerializeField]
    Image ClickMenuBar;


    bool OCflg = false;


	// Use this for initialization
	void Start () {

        //メニューバーの初期位置
        transform.position = new Vector3(110.0f, 140.0f, 0.0f);

        EventTrigger trigger = ClickMenuBar.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        // なんのイベントを検出するか
        entry.eventID = EventTriggerType.PointerClick;
        // コールバック登録
        entry.callback.AddListener(OnSlideMenu);

        // EventTriggerに追加
        trigger.triggers.Add(entry);

        

    }
	
	// Update is called once per frame
	void Update () {
		
	}



    public void OnSlideMenu(BaseEventData eventData)
    {


        if (OCflg == false)
        {
            transform.position = new Vector3(110.0f, 140.0f, 0.0f);
            OCflg = true;
        }
        else if(OCflg == true)
        {

            transform.position = new Vector3(110.0f, 190.0f, 0.0f);
            OCflg = false;

        }

    }


}
