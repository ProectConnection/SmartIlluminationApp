using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeBase : MonoBehaviour {
    string noticeParam;

    GameObject ParamGO;
    GameObject TexGO;
    GameObject BgGO;
    
	// Use this for initialization
	void Start () {
        
	}

    //NoticeBaseを生成後に必ずこの関数を実行する
    //noticeSpriteImg...通知アイコン　newNoticeParam...通知文
    public void StartingNotice(Sprite noticeSpriteImg,string newNoticeParam)
    {
        TexGO = transform.Find("NoticeImg").gameObject;
        ParamGO = transform.Find("NoticeText").gameObject;

        TexGO.GetComponent<UnityEngine.UI.Image>().sprite = noticeSpriteImg;
        ParamGO.GetComponent<UnityEngine.UI.Text>().text = newNoticeParam;
        PreserveDestroyNotice();
    }

    //NoticeBaseを生成後に必ずこの関数を実行する
    //noticeSpriteImg...通知アイコン　newNoticeParam...通知文
    public void StartingNotice(Sprite BGImage)
    {
        BgGO = transform.Find("NoticeBG").gameObject;

        BgGO.GetComponent<UnityEngine.UI.Image>().sprite = BGImage;

        PreserveDestroyNotice();
    }

    void PreserveDestroyNotice()
    {
        Destroy(this.gameObject, 10.0f);    //仮で10秒で削除にしている
    }
}
