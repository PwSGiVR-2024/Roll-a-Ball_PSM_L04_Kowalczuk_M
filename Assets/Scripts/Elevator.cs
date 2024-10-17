using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector = Vector3.zero;
    [SerializeField] float movementLimit = 2f, currentMovement = 0f;
    [SerializeField] GameObject hitbox;

    private void Update()
    {
            transform.position += movementVector * Time.deltaTime;
            currentMovement += Time.deltaTime;
            if (currentMovement >= movementLimit)
            {
                movementVector = -movementVector;
                currentMovement = currentMovement - movementLimit;
            }
    }
}
