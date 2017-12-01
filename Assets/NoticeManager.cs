using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeManager : MonoBehaviour{
    [SerializeField]
    GameObject Pre_Notice;

    public void CreateNotice(Sprite constructSprite,string noticeMessage)
    {
        GameObject tnotice = Object.Instantiate(Pre_Notice, GameObject.Find("Canvas").transform);
        tnotice.GetComponent<NoticeBase>().StartingNotice(constructSprite, noticeMessage);
    }

    public void CreateNotice(Sprite BGImage)
    {
        GameObject tnotice = Object.Instantiate(Pre_Notice, GameObject.Find("Canvas").transform);

        tnotice.GetComponent<NoticeBase>().StartingNotice(BGImage);
    }
}
