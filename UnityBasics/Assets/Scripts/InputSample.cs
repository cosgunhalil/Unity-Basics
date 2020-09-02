using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSample : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Pressed to A");
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("Pressed Up to A");
        }

        if (Input.GetMouseButtonDown(0))//sol click
        {
            Debug.Log("Left Click!");
        }
        else if (Input.GetMouseButtonDown(1)) // sağ click
        {
            Debug.Log("Right Click");
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Horizontal = " + horizontal + " / " + "Vertical = " + vertical);
        }

        //development mode'da bir in game logger açmak kapamak istiyorsunuz, 
        if (Input.touchCount > 0)
        {
            Debug.Log("Touch Count = " + Input.touchCount);

            //https://docs.unity3d.com/ScriptReference/Input.GetTouch.html
        }
    }
}
