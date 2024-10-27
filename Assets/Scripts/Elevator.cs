using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector, centerPoint;
    [SerializeField] float movementLimit = 2f, currentMovement = 0f, movementSpeed;

    private void Start()
    {
        centerPoint = transform.position;
    }

    private void Update()
    {
        float passedTime = Time.deltaTime;
        transform.position += movementVector * passedTime * movementSpeed;
        currentMovement += passedTime * movementSpeed;
        if (currentMovement >= movementLimit)
        {
            movementVector = -movementVector;
            currentMovement = currentMovement - movementLimit;
        }
    }
}
