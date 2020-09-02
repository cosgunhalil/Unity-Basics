using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCollisionComponent))]
public class Player2dController : MonoBehaviour
{
    private PlayerCollisionComponent collisionComponent;

    void Start()
    {
        collisionComponent = GetComponent<PlayerCollisionComponent>();

        var parent = new GameObject("PlayerParentObject");
        transform.SetParent(parent.transform);
        
    }

}
