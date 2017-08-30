using UnityEngine;
using System.Collections;

public class JumpMove : MonoBehaviour {

    [SerializeField]
    Rigidbody2D rb2d;
    [SerializeField]
    float initialJumpPower;
    float jumpPower;
    [SerializeField]
    float decreasePower;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	
    public void Jump()
    {
        StartCoroutine(WhileJump());
    }
    /*
    JumpPower ← InitialJumpPower 
    Jumppower分の力をRigidBodyで加え続け、
    加える力が0になった時点で
    ジャンプ挙動を終了する
    */
    IEnumerator WhileJump()
    {
        jumpPower = initialJumpPower;
        while (true) {
            rb2d.AddForce(new Vector2(0,jumpPower));
            jumpPower -= decreasePower;
            if (jumpPower <= 0.0f)
            {
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
