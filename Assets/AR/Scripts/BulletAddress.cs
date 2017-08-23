using UnityEngine;
using System.Collections;

public class BulletAddress : MonoBehaviour {
    [SerializeField]
    HitBullet Com_hitBullet;
    [SerializeField]
    Element Com_Element;
    [SerializeField]
    BulletMove Com_BulletMove;

    public Element element {
        get{
            return Com_Element;
        }
    }

    public HitBullet hitBullet
    {
        get
        {
            return Com_hitBullet;
        }
    }

    public BulletMove bulletMove
    {
        get
        {
            return Com_BulletMove;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
