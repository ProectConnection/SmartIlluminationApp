using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class false_CMP : MonoBehaviour
{
	public Text text;

    private Vector3 acceleration;
    private static AccelerationEvent[]accelerationEvent;
    
    private int  counttext = 0;
    private int countDeck = 0;
    public float speed =00.10F;
   // public float SetPersistentListenerState(int index,Events.UnityEventCallState state);
    private DataSaver ref_DataSaver;
    public int BoxMin;
    public int BoxMax;
void Start()
{
   /* Application.runInBackground = true;
    Debug.Log("Application.runInBackground:"+Application.runInBackground);*/
		text = this.GetComponent<Text>();
        ref_DataSaver = DataSaver.GetDataSaver();

        
}
     void Update(){
#if !UNITY_ANDROID
        //transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
        if (acceleration != null)
        {
            float x = Screen.width / 10;
            float y = 0;
            float w = Screen.width * 8 / 10;
            float h = Screen.height / 20;
            
            for (int i = 0; i < 1; i++)
            {

                Vector3 countDeck = Vector3.zero;
                countDeck.x = -Input.acceleration.y;
                countDeck.z = Input.acceleration.x;        

                 if(countDeck.x < -1.03732 ){
                     counttext += 1;
                    
                    }
                    else if(countDeck.x > -0.75000){
                        break;
                }
            }
        }
        ref_DataSaver.SetNewPedocount(((float) counttext).ToString(), PEDOCOUNTSETMODE.ADDCITIVE);
#endif
    }
}
