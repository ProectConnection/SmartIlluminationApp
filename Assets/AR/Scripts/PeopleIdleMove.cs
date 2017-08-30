using UnityEngine;
using System.Collections;
[RequireComponent(typeof(XAxisMoveComponent))]
public class PeopleIdleMove : MonoBehaviour {
    [SerializeField]
    XAxisMoveComponent Com_XAxisMove;
    [SerializeField]
    float TurnSecond;
    float inputaxis = 1.0f;

    float TurnCount;
	// Update is called once per frame
	void Update () {
        TurnCount += Time.deltaTime;
        Com_XAxisMove.XMove(inputaxis);
        if (TurnCount >= TurnSecond)
        {
            inputaxis *= -1;
            TurnCount = 0.0f;
        }
        
	}
}
