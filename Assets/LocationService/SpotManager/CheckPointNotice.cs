using UnityEngine;

class CheckPointNotice : MonoBehaviour
{
    SpotManager ref_SpotManager;
    SpotData prevSpotData;
    [SerializeField]
    GameObject Pre_Notice;
    [SerializeField]
    Transform CanvasTransform;
    [SerializeField]
    Sprite deb_constructSprite;
    NoticeManager ref_NoticeManager;
    private void Start()
    {
        ref_SpotManager = GetComponent<SpotManager>();
        ref_SpotManager.OnChangedNearestSpot.AddListener(OnChangedNearestSpot);
        ref_NoticeManager = GameObject.Find("NotiManager").GetComponent<NoticeManager>();
    }

    private void OnChangedNearestSpot()
    {
        if(ref_SpotManager.nearestSpotData != null)
        {
            if (prevSpotData != ref_SpotManager.nearestSpotData)
            {
                ref_NoticeManager.CreateNotice(deb_constructSprite, "チェックポイント\n" + ref_SpotManager.nearestSpotData.name + "に\n到着しました！");
                //tnotice.GetComponent<RectTransform>().position = new Vector3(-194f, 673f);
            }
        }
        prevSpotData = ref_SpotManager.nearestSpotData;
    }
}