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
    private void Start()
    {
        ref_SpotManager = GetComponent<SpotManager>();
        ref_SpotManager.OnChangedNearestSpot.AddListener(OnChangedNearestSpot);
    }

    private void OnChangedNearestSpot()
    {
        if(ref_SpotManager.nearestSpotData != null)
        {
            if (prevSpotData != ref_SpotManager.nearestSpotData)
            {
                //Debug.Log(ref_SpotManager.ToString() + "に到着しました！");
                GameObject tnotice = Instantiate(Pre_Notice,GameObject.Find("Canvas").transform);
                tnotice.GetComponent<RectTransform>().position = new Vector3(-194f, 673f);
                tnotice.GetComponent<NoticeBase>().StartingNotice(deb_constructSprite, "チェックポイント\n" + ref_SpotManager.nearestSpotData.name + "に\n到着しました！");
            }
        }
        prevSpotData = ref_SpotManager.nearestSpotData;
    }
}