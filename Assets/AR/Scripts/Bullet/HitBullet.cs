using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Collider2D))]

public class HitBullet : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
