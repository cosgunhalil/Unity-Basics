using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection3D : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("On Collision Enter - Touch the ground!");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("On Collision Exit");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("On Collision Stay");
    }
}
