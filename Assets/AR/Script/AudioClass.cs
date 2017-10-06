using UnityEngine;
using System.Collections;

public class AudioClass : MonoBehaviour {
    [SerializeField]
    AudioSource Com_AudioSource;
	
	// Update is called once per frame
	void Update () {
	    if(Com_AudioSource.isPlaying == false)
        {

        }
	}
}
