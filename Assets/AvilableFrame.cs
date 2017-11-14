using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvilableFrame : MonoBehaviour {
    [SerializeField]
    FrameId thisFrameId;
    [SerializeField]
    FrameUnlocker ref_FrameUnlocker;
    Image thisImage;

    UnityEngine.UI.Button thisButton;
	// Use this for initialization
	void Start () {
        thisButton = GetComponent<UnityEngine.UI.Button>();
        thisImage = GetComponent<Image>();
        thisButton.onClick.AddListener(OnPress);
        if (ref_FrameUnlocker.IsAviliableFrame(thisFrameId))
        {
            //フレームが使える時の処理
            if (thisFrameId == FrameId.SpotFrame)
            {
               thisImage.sprite = GameObject.FindGameObjectWithTag("SpotManager").GetComponent<SpotManager>().nearestSpotData.GetPhotoFrame(0);
            }
        }
        else
        {
            //フレームが使えない時の処理
            thisButton.interactable = false;
            thisImage.color = Color.gray;
        }
	}

    public void OnPress()
    {
        ref_FrameUnlocker.AcriveFrame(thisFrameId, !(ref_FrameUnlocker.GetActiveFrame(thisFrameId)));
    }
}
