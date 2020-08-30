using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingRigidbody : MonoBehaviour
{
    private Rigidbody rigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();

        rigidbodyComponent.AddForce(Vector3.up * 100f, ForceMode.Impulse);
    }
}
