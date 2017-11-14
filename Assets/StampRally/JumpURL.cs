using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JumpURL : MonoBehaviour {


    [SerializeField]
    Image ClickImage;


    // Use this for initialization
    void Start () {

        EventTrigger trigger = ClickImage.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        // なんのイベントを検出するか
        entry.eventID = EventTriggerType.PointerClick;
        // コールバック登録
        entry.callback.AddListener(OnURL);

        // EventTriggerに追加
        trigger.triggers.Add(entry);

    }
	
	// Update is called once per frame
	void Update () {

       

    }

    
    public void OnURL(BaseEventData eventData)
    {

        //Application.OpenURL("http://narudesign.com/");


        if (gameObject.name == "Seaside")
        {
            Application.OpenURL("http://www.seasideline.co.jp/");
        }
        if (gameObject.name == "Shounan")
        {
            Application.OpenURL("http://www.shonan-monorail.co.jp/");
        }
        if (gameObject.name == "Joyhose")
        {
            Application.OpenURL("http://www.joyhorse-yokohama.co.jp/");
        }
        if (gameObject.name == "Minatomirai")
        {
            Application.OpenURL("https://www.facebook.com/4.1sanpo");
        }
        if (gameObject.name == "Taiiku")
        {
            Application.OpenURL("http://www2.yspc.or.jp/ysa/");
        }
        if (gameObject.name == "YDA")
        {
            Application.OpenURL("http://yda.iwasaki.ac.jp");
        }

    }


}
