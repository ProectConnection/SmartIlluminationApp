using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAdditionalLoad : MonoBehaviour {
    Camera mainCamera;
    [SerializeField]
    Vector2 nextLoadDiff;
    GoogleMapManager ref_GoogleMapManager;
    [SerializeField]
    GoogleMapDrawer ref_ParentGoogleMapDrawer;
    [SerializeField]
    Transform ParentTransform;
	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;
        ref_GoogleMapManager = GameObject.FindGameObjectWithTag("GoogleMapManager").GetComponent<GoogleMapManager>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CentMapDrawer"))
        {
            DestroyThisCollider();
        }

        if (other.gameObject.CompareTag("MainCamera") || other.gameObject.CompareTag("Player"))
        {
            ref_GoogleMapManager.AdditinalMapLoad(nextLoadDiff,ParentTransform,ref_ParentGoogleMapDrawer.googleMapPictureCoord);
            DestroyThisCollider();
        }
    }

    void DestroyThisCollider()
    {
        Destroy(this.gameObject);
    }
}
