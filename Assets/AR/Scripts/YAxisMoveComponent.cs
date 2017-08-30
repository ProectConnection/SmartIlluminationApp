using UnityEngine;
using System.Collections;

public class YAxisMoveComponent : MonoBehaviour {

    [SerializeField]
    float movespeed; //移動速度
    /*
    +YMove(float 軸値)
    このスクリプトをアタッチしているオブジェクトを、
    y軸方向にTransform移動する
    */
    public void YMove(float axisValue)
    {
        transform.position += new Vector3(0, axisValue * movespeed, 0);

    }
}
