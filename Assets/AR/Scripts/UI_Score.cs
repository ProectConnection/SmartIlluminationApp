using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour {
    [SerializeField]
    Text UI_ScoreLbl;
	// Update is called once per frame
	void Update () {
        UI_ScoreLbl.text = (ScoreObject.score).ToString();
	}
}
