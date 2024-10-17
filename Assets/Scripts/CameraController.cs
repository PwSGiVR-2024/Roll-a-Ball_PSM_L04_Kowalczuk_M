using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 playerToCameraVector;

    void Start()
    {
        playerToCameraVector =  transform.position - playerTransform.position;
    }


    void FixedUpdate()
    {
        transform.position = playerTransform.position + playerToCameraVector;
    }
}
