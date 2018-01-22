using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThumbnailCheck : MonoBehaviour {
    
    public GameObject ThumnailChecks;
    public bool Thumnailflg;
	// Use this for initialization
	void Start () {
        ThumnailChecks.SetActive(false);
        Thumnailflg = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnThumnail()
    {
        //ボタンが押されたら大サイズのサムネイル表示
        if (Thumnailflg == false)
        {
            ThumnailChecks.SetActive(true);
            Thumnailflg = true;
        }
        else if (Thumnailflg == true)
        {
            ThumnailChecks.SetActive(false);
            Thumnailflg = false;
        }
    }
}
