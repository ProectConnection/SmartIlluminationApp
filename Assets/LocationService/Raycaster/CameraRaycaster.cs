using UnityEngine;

public class CameraRaycaster : MonoBehaviour {
    [SerializeField]
    Camera OriginCamera;
    [SerializeField]
    LayerMask TargetLayer;
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
        if (Input.touchCount > 0)
        {
            //タップされている時に、スポット用のレイキャストを飛ばす
            if (Input.GetTouch(0).phase < TouchPhase.Ended)
            {
                RaycastHit hitinfo;
                if (Physics.Raycast(OriginCamera.ScreenPointToRay(Input.GetTouch(0).position), out hitinfo, Mathf.Infinity, TargetLayer) && hitinfo.transform.gameObject.CompareTag("Spot"))
                {
                    hitinfo.collider.gameObject.GetComponent<SpotClass>().SpotIntaract();
                }
            }
        }
	}
}
