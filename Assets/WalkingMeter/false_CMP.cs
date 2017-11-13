using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class false_CMP : MonoBehaviour
{
	public Text text;
    private Vector3 acceleration;
    

/// <summary>
/// Start is called on the frame when a script is enabled just before
/// any of the Update methods is called the first time.
/// </summary>
void Start()
{
		text = this.GetComponent<Text>();
        
}
    // Update is called once per frame
     void Update(){
        if (acceleration != null)
        {
            float x = Screen.width / 10;
            float y = 0;
            float w = Screen.width * 8 / 10;
            float h = Screen.height / 20;
            string countDeck = string.Empty;
            string counttext = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                y = Screen.height / 10 + h * i;
               

                switch (i)
                {
                    //case 0://X
                       // ngotext += string.Format("accel-X:{0}", System.Math.Round(this.acceleration.x, 3));
                        //break;
                    case 0://Y
                        countDeck += string.Format("accel-Y:{0}", System.Math.Round(this.acceleration.y, 3));
                        break;
                    case 1://Z
                        countDeck += string.Format("accel-Z:{0}", System.Math.Round(this.acceleration.z, 3));
                        break;
                    default:
                        throw new System.InvalidOperationException();
                }
               // ngotext += "\n";
             if(countDeck != null){
                 for(int acceleration =0; acceleration < 0.0010 ; acceleration++){
                    counttext += 1;
                    
                    }           
                }
            text.text =counttext;
            }
        }

	}
}
