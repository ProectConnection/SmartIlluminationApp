using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Collider2D))]
public class PeopleHit : MonoBehaviour {
    [SerializeField]
    Element Com_Element;
    [SerializeField]
    FollowMove Com_FollowMove;
    [SerializeField]
    PeopleIdleMove Com_PeopleIdleMove;
    
    

    Element Com_t_OtherElement;
    bool[] MatchElements = new bool[sizeof(ELEMENT)];

    int i;

    void Start()
    {
        MatchElements = Com_Element.GetMatchElement();
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        
        if(other.gameObject.tag == "Arena")
        {
            PeopleIntoArena();
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Bullet")
        {
            Com_t_OtherElement = other.gameObject.GetComponent<Element>();

            for (i = 0; i < sizeof(ELEMENT); i++)
            {
                if ((Com_t_OtherElement.IsMatchElement(i) == true))
                {
                    if (MatchElements[i] == true)
                    {
                        MatchElementHit();
                    }
                }
            }
        }
    }

    void MatchElementHit()
    {
        Com_FollowMove.enabled = true;
        Com_PeopleIdleMove.enabled = false;
        Com_FollowMove.SetTarget(GameObject.FindGameObjectWithTag("Player"));
    }

    void DestroyPeople(){
        Destroy(gameObject);
    }

    void PeopleIntoArena()
    {
        ScoreObject.AddScore();
        DestroyPeople();
    }
}
