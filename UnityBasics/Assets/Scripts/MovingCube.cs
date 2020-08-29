using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    private Vector3 targetPosition;
    private Transform cubeTransform;
    private float speed = 13.5f;

    private float time;//Yeni bir pozisyon ne zaman belirlensin diye tutuluyor

    private const float targetChangeFrequency = 1.5f;
    private const float positionXLimit = 10f;
    private const float positionYLimit = 10f;
    private const float positionZLimit = 10f;

    private const float distance = .3f;

    private Vector3 rotateAmount = new Vector3(10, -25, 77);

    void Start()
    {
        cubeTransform = GetComponent<Transform>();
        targetPosition = new Vector3(-10, 10, 10);
    }

    void Update()
    {
        //ExecuteVectorMathMovement();
        ExecuteMoveTowardsSample();
        IncreaseTime();

        Rotate();

    }

    private void ExecuteVectorMathMovement()
    {
        if (!IsReachToTarget())
        {
            Move();
        }
    }

    private bool IsReachToTarget()
    {
        return Vector3.Distance(cubeTransform.position, targetPosition) < distance;
    }

    private void Move()
    {
        var currentPosition = cubeTransform.position;
        var direction = targetPosition - currentPosition;

        var normalizedDir = direction.normalized;//1 birimlik, üzerine hız uygulanabilecek bir vektörümüz var.

        var nextPosition = currentPosition + normalizedDir * speed * Time.deltaTime;

        cubeTransform.position = nextPosition;
    }

    private void IncreaseTime()
    {
        time += Time.deltaTime;

        if (time > targetChangeFrequency)
        {
            time = 0;
            SetNewRandomTarget();
            SetNewRandomScale();
        }
    }

    private void SetNewRandomTarget()
    {
        targetPosition = new Vector3(
            UnityEngine.Random.Range(-positionXLimit, positionXLimit),
            UnityEngine.Random.Range(-positionYLimit, positionYLimit),
            UnityEngine.Random.Range(-positionZLimit, positionZLimit)
            );
    }

    private void ExecuteMoveTowardsSample()
    {
        cubeTransform.position = Vector3.MoveTowards(transform.position,
            targetPosition, speed * Time.deltaTime);
    }

    private void Rotate()
    {
        cubeTransform.Rotate(rotateAmount * Time.deltaTime);
        //cubeTransform.localEulerAngles = new Vector3(15, 15, 15);
    }

    private void SetNewRandomScale()
    {
        var min = .1f;
        var max = 1.5f;

        cubeTransform.localScale = new Vector3(
            UnityEngine.Random.Range(min, max),
            UnityEngine.Random.Range(min, max),
            UnityEngine.Random.Range(min, max));
    }
}
