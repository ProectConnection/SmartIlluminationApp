using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class false_CMP : MonoBehaviour
{
	public Text text;

    private Vector3 acceleration;
    
    private int  counttext = 0;
    private int countDeck = 0;
    public float speed =00.10F;
    private DataSaver ref_DataSaver;
/// <summary>
/// Start is called on the frame when a script is enabled just before
/// any of the Update methods is called the first time.
/// </summary>
void Start()
{
		text = this.GetComponent<Text>();
        ref_DataSaver = DataSaver.GetDataSaver();
        
}
    // Update is called once per frame
     void Update(){
         //transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
        if (acceleration != null)
        {
            float x = Screen.width / 10;
            float y = 0;
            float w = Screen.width * 8 / 10;
            float h = Screen.height / 20;
            //string countDeck = string.Empty;
            
            for (int i = 0; i < 1; i++)
            {
                //y = Screen.height / 10 + h * i;

                Vector3 countDeck = Vector3.zero;
                countDeck.x = -Input.acceleration.y;
                countDeck.z = Input.acceleration.x;

               /* if(countDeck.sqrMagnitude > 1)
                countDeck.Normalize();

                countDeck *= Time.deltaTime;
                transform.Translate(countDeck * speed);
*/
               // ngotext += "\n";
            // if(countDeck != null){
                 if(countDeck.x < -0.93732 ){
                     counttext += 1;
                    
                    }
            //text.text = counttext.ToString();
            }
        }
        ref_DataSaver.SetNewPedocount(((float) counttext).ToString(), PEDOCOUNTSETMODE.ADDCITIVE);
    }
}
