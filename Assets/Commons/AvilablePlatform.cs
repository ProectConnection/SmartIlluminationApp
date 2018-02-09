using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvilablePlatform : MonoBehaviour {
    //アタッチされているゲームオブジェクトが使用可能なプラットフォームのリスト
    [SerializeField]
    RuntimePlatform[] AvilablePlatforms;
	// Use this for initialization
	void Start () {
		foreach(RuntimePlatform ap in AvilablePlatforms)
        {
            if (ap == Application.platform)
            {
                return;
            }
        }
        gameObject.SetActive(false);
	}

}
