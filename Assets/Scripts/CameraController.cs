using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 playerToCameraVector;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerToCameraVector =  transform.position - playerTransform.position;
    }


    void Update()
    {
        transform.position = playerTransform.position + playerToCameraVector;
    }
}
