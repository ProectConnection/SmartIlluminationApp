using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycaster : MonoBehaviour {
    [SerializeField]
    Camera OriginCamera;
    [SerializeField]
    LayerMask TargetLayer;
    Touch[] touches;
	// Use this for initialization
	void Start () {
		if(OriginCamera == null)
        {
            Debug.Log("レイキャストを射出するカメラが指定されていません！\nMainCameraを取得し使用します");
            OriginCamera = Camera.main;
        }
	}
	
	// Update is called once per frame
	void Update () {
        touches = Input.touches;
        if(touches.Length > 0)
        {
            Touch firstTouch = touches[0];
            if (firstTouch.phase < TouchPhase.Ended)
            {
                RaycastHit hitinfo;
                Physics.Raycast(OriginCamera.ScreenPointToRay(firstTouch.position), out hitinfo, 100, TargetLayer);
                if((hitinfo.collider != null) && hitinfo.collider.CompareTag("Spot"))
                {
                    Debug.Log("Ray Hit");
                    hitinfo.collider.gameObject.GetComponent<SpotClass>().SpotIntaract();
                }
            }
        }
	}
}
