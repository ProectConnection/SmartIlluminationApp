using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycaster : MonoBehaviour {
    [SerializeField]
    Camera OriginCamera;
    [SerializeField]
    LayerMask TargetLayer;
    Renderer thisrenderer;  //デバッグ用、スポットヒット時に点灯するランプ
	// Use this for initialization
	void Start () {
		if(OriginCamera == null)
        {
            Debug.Log("レイキャストを射出するカメラが指定されていません！\nMainCameraを取得し使用します");
            OriginCamera = Camera.main;
        }
        thisrenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            //タップされている時に、スポット用のレイキャストを飛ばす
            if (Input.GetTouch(0).phase < TouchPhase.Ended)
            {
                RaycastHit hitinfo;
                if (Physics.Raycast(OriginCamera.ScreenPointToRay(Input.GetTouch(0).position), out hitinfo, Mathf.Infinity, TargetLayer) && hitinfo.transform.gameObject.CompareTag("Spot"))
                {
                    thisrenderer.enabled = true;
                    hitinfo.collider.gameObject.GetComponent<SpotClass>().SpotIntaract();
                }
            }
        }
        else
        {
            thisrenderer.enabled = false;
        }
	}
}
