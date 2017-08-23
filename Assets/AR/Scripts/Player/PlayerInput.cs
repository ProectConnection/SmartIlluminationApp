using UnityEngine;
using System.Collections;

[RequireComponent(typeof(XAxisMoveComponent))]

public class PlayerInput : MonoBehaviour
{
    float xAxisVal;
    bool shotFlg = false;
    bool jumpFlg = false;
    float coolDownTimer;
    [SerializeField, Range(0.0f, Mathf.Infinity)]
    float coolDownTime;
    [SerializeField]
    XAxisMoveComponent com_XAxisMoveComponent;
    [SerializeField]
    GameObject Pre_Bullet;
    [SerializeField]
    SpriteRenderer Com_SpriteRenderer;
    [SerializeField]
    JumpMove Com_JumpMove;
    [SerializeField]
    PouseManager Com_PouseManager;
    [SerializeField]
    Transform BulletParent;
    [SerializeField]
    Element Com_element;
    [SerializeField]
    GameObject GM_ASJump;
    [SerializeField]
    GameObject GM_ASShout;
    [SerializeField]
    Fukidasi GM_Fukidasi;

    bool[] temp_thisElement;

    BulletAddress Temp_BulletAddress;

    GameObject Temp_Bullet;


    // Update is called once per frame
    void Update()
    {
        //移動処理
        if ((xAxisVal = Input.GetAxis("Horizontal")) != 0.0f)
        {
            Com_SpriteRenderer.flipX = (xAxisVal < 0.0f) ? true : false;
            com_XAxisMoveComponent.XMove(xAxisVal);
        }

        if (shotFlg == false) //弾を撃ちだせる状態の時
        {
            if (Input.GetButton("Fire1"))
            {
                ShotBullet();
                shotFlg = true;
                coolDownTimer = 0.0f;
            }
        }
        else //弾発射クールダウン処理
        {
            coolDownTimer += Time.deltaTime;
            if (coolDownTimer >= coolDownTime)
            {
                shotFlg = false;
            }
        }
        //ジャンプ
        if (Input.GetAxis("Jump") != 0.0f)
        {
            if (jumpFlg == false)
            {
                Com_JumpMove.Jump();
                jumpFlg = true;
                Instantiate(GM_ASJump);
            }
        }

    }
    /*
     弾を打ち出す時の関数
         */
    void ShotBullet()
    {
        Temp_Bullet = (GameObject)Instantiate(Pre_Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
        Temp_Bullet.transform.SetParent(BulletParent);
        Temp_BulletAddress = Temp_Bullet.GetComponent<BulletAddress>();
        //飛翔体呼びかけの時の名残
        //Temp_BulletAddress.bulletMove.SetAxis((Com_SpriteRenderer.flipX == true) ? -1.0f : 1.0f);
        temp_thisElement = Com_element.GetMatchElement();
        for (int i = 0; i < sizeof(ELEMENT); i++)
        {
            Temp_BulletAddress.element.SetMatchElement(i, temp_thisElement[i]);
        }
        Instantiate(GM_ASShout);

        GM_Fukidasi.ChangeVisible(true);
    }

    public void SetJumpFlg(bool tJumpFlg)
    {
        jumpFlg = tJumpFlg;
    }
}
