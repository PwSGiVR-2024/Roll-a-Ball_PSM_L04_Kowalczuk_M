using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform spawnPointTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovementController>() != null)
        {
            spawnPointTransform.transform.position = transform.position;
        }
    }
}
