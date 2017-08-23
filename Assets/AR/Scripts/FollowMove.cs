using UnityEngine;
using System.Collections;
[RequireComponent(typeof(XAxisMoveComponent))]
[RequireComponent(typeof(YAxisMoveComponent))]
[RequireComponent(typeof(JumpMove))]

public class FollowMove : MonoBehaviour {
    [SerializeField]
    GameObject Target;
    [SerializeField]
    XAxisMoveComponent Com_XAxisMove;
    [SerializeField]
    YAxisMoveComponent Com_YAxisMove;
    [SerializeField]
    JumpMove Com_JumpMove;
    float PlayerRad;
    bool jumpableflg = false;
	// Update is called once per frame
	void Update () {
        PlayerRad = Mathf.Atan2(Target.transform.position.y - transform.position.y,
                    Target.transform.position.x - transform.position.x);

        if (Target.transform.position.y >= transform.position.y + 1.0f) {        
            if (jumpableflg == true)
            {
                Com_JumpMove.Jump();
                jumpableflg = false;
            }
        }
        Com_XAxisMove.XMove(Mathf.Cos(PlayerRad));
    }

    public void SetTarget(GameObject ttarget)
    {
        Target = ttarget;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Ground":
                jumpableflg = true;
                break;
        }
    }
}
