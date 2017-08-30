using UnityEngine;
using System.Collections;

public class XAxisMoveComponent : MonoBehaviour {
    
    [SerializeField]
    float movespeed; //移動速度
    /*
    +XMove(float 軸値)
    このスクリプトをアタッチしているオブジェクトを、
    x軸方向にTransform移動する
    */
    public void XMove(float axisValue)
    {
        transform.position += new Vector3(axisValue * movespeed,0,0);

    }
}
