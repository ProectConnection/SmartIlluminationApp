using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Locator))]
public class LocatorTextChanger : MonoBehaviour {
    
    Text lat_val_text;
    Text long_val_text;
    Locator locator;

	// Use this for initialization
	void Start () {
        lat_val_text = GameObject.FindGameObjectWithTag("lat_val").GetComponent<Text>();
        long_val_text = GameObject.FindGameObjectWithTag("long_val").GetComponent<Text>();
        locator = gameObject.GetComponent<Locator>();
    }
	
	// Update is called once per frame
	void Update () {
        lat_val_text.text = (locator.locationCoordination.GetLatitude.ToString("f3"));
        long_val_text.text = (locator.locationCoordination.GetLongitude.ToString("f3"));
    }
}
