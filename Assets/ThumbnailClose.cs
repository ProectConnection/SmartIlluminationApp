using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThumbnailClose : MonoBehaviour {
    MaterialPropertyBlock block;
    public ThumbnailCheck TC;
    // Use this for initialization
    void Start()
    {
        block = new MaterialPropertyBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Renderer>().SetPropertyBlock(null);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Renderer>().SetPropertyBlock(block);
             if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))//※スマートフォン（AndroidやiOS）でのビルドの時に使用
            //if (EventSystem.current.IsPointerOverGameObject())//PCでのデバッグの際に使用
            {

                return;
            }


            if (TC.Thumnailflg == true)
            {
                TC.ThumnailChecks.SetActive(false);

                TC.Thumnailflg=false;
            }
        }
    }
}
