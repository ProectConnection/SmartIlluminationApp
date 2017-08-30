using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class PlayerHit : MonoBehaviour {
    [SerializeField]
    PlayerInput Com_PlayerInput;
    [SerializeField]
    Element Com_PlayerElement;

    //接触相手のコンポーネントを一時保存
    Element Com_t_OtherElement;
    bool[] t_ItemElement;

    [SerializeField]
    Sprite[] YokoariPictures;
    [SerializeField]
    SpriteRenderer Com_SpriteRender;
    
    //カウント変数
    int i;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Com_PlayerInput.SetJumpFlg(false);
        }

        if (other.gameObject.tag == "Item")
        {

            Com_t_OtherElement = other.gameObject.GetComponent<Element>();
            t_ItemElement = Com_t_OtherElement.GetMatchElement();
            for(i = 0; i < sizeof(ELEMENT); i++)
            {
                Com_PlayerElement.SetMatchElement(i, t_ItemElement[i]);
                if(Com_PlayerElement.IsMatchElement(i) == true)
                {
                    Com_SpriteRender.sprite = YokoariPictures[i];
                }
            }
            Destroy(other.gameObject);
        }
    }

    void Hensin(int orderNo = 0)
    {
        for (i = 0; i < sizeof(ELEMENT); i++)
        {
            Com_PlayerElement.SetMatchElement(i, t_ItemElement[i]);
            
        }
        Com_PlayerElement.SetMatchElement(orderNo, true);
        Com_SpriteRender.sprite = YokoariPictures[orderNo];
        
    }
}