using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuBar : MonoBehaviour {



    public GameObject CloseMenu;
    public GameObject OpenMenu;





    /*
    [SerializeField]
    Image ClickMenuBar;


    bool OCflg = false;

    public GameObject CloseMenu;
    public GameObject OpenMenu;
    */



    // Use this for initialization
    void Start () {


        /*
        EventTrigger trigger = ClickMenuBar.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        // なんのイベントを検出するか
        entry.eventID = EventTriggerType.PointerClick;
        // コールバック登録
        entry.callback.AddListener(OnSlideMenu);

        // EventTriggerに追加
        trigger.triggers.Add(entry);


        CloseMenu.SetActive(true);
        OpenMenu.SetActive(false);


        OCflg = false;
        */

        CloseMenu.SetActive(true);
        OpenMenu.SetActive(false);



    }

    // Update is called once per frame
    void Update () {
		
	}



    public void OnOpenMenu()
    {


        OpenMenu.SetActive(true);
        CloseMenu.SetActive(false);


    }

    public void OnCloseMenu()
    {


        OpenMenu.SetActive(false);
        CloseMenu.SetActive(true);


    }



    /*

    public void OnSlideMenu(BaseEventData eventData)
    {



        

        Debug.Log("(∩´∀｀)∩");


        if (OCflg == false)
        {
            //transform.position = new Vector3(110.0f, 140.0f, 0.0f);
            CloseMenu.SetActive(false);
            OpenMenu.SetActive(true);
            OCflg = true;
        }
        else if(OCflg == true)
        {

            //transform.position = new Vector3(110.0f, 190.0f, 0.0f);
            CloseMenu.SetActive(true);
            OpenMenu.SetActive(false);
            OCflg = false;

        }

    }*/


}
