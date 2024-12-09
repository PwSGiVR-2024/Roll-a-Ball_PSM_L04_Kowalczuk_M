using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    public event Action pickupEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & playerMask) != 0)
        {        
            gameObject.SetActive(false);
            pickupEvent?.Invoke();
        }
    }
}
