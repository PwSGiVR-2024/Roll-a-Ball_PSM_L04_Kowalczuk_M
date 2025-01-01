using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 playerToCameraVector;

    void Start()
    {
        Debug.Log(gameObject.name);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerToCameraVector =  transform.position - playerTransform.position;
    }

    void Update()
    {
        if (playerTransform)
        {
            transform.position = playerTransform.position + playerToCameraVector;
        }
    }
}
