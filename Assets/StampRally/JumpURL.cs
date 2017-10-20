using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpURL : MonoBehaviour {

	// Use this for initialization
	void Start () {

        
		
	}
	
	// Update is called once per frame
	void Update () {

       

    }

    
    public void OnURL()
    {

        //Application.OpenURL("http://narudesign.com/");


        if (gameObject.name == "YDA")
        {
            Application.OpenURL("http://yda.iwasaki.ac.jp");
        }
        if (gameObject.name == "YFC")
        {
            Application.OpenURL("http://yfc.iwasaki.ac.jp");
        }
        if (gameObject.name == "ISC")
        {
            Application.OpenURL("http://isc.iwasaki.ac.jp/");
        }
        if (gameObject.name == "ISCS")
        {
            Application.OpenURL("http://iscs.iwasaki.ac.jp/");
        }
        if (gameObject.name == "HOIKU")
        {
            Application.OpenURL("http://hoiku.iwasaki.ac.jp");
        }
        if (gameObject.name == "YCR")
        {
            Application.OpenURL("http://ycr.iwasaki.ac.jp");
        }

    }


}
