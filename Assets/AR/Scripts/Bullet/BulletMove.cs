using UnityEngine;
using System.Collections;

[RequireComponent(typeof(XAxisMoveComponent))]

public class BulletMove : MonoBehaviour {

    float axis = 1.0f;
    [SerializeField]
    float shootDistance;
    Vector2 shootStartPosition;
    [SerializeField]
    XAxisMoveComponent com_XAxisMoveComponent;
    
    void Start()
    {
        shootStartPosition = transform.position;
    }

    // Update is called once per frame
    void Update () {
        com_XAxisMoveComponent.XMove(axis);
        //射程距離
        if (shootDistance * shootDistance <= ((transform.position.x - shootStartPosition.x) * (transform.position.x - shootStartPosition.x) +
                                              (transform.position.y - shootStartPosition.y) * (transform.position.y - shootStartPosition.y)))
        {
            Destroy(gameObject);
        }
	}

    public void SetAxis(float tAxis)
    {
        axis = tAxis;
    }
}
