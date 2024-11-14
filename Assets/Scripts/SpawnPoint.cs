using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float fallLevel = -1;

    private void Update()
    {
        if(playerTransform.position.y <= fallLevel)
        {
            playerTransform.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            playerTransform.position = transform.position;
        }
    }
}
