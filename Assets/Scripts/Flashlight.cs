using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour 
{
    private Transform playerTransform;
    private Vector3 playerToFlashlightVector;
    [SerializeField] Rigidbody playerRB;
    [SerializeField] private int range;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerRB = playerTransform.GetComponent<Rigidbody>();
        playerToFlashlightVector = transform.position - playerTransform.position;
    }
    void Update()
    {
        transform.position = playerTransform.position + playerToFlashlightVector;
        transform.forward = playerRB.linearVelocity;
    }
}