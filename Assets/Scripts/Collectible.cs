using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public event Action pickupEvent;
    private void Update()
    {
        transform.Rotate(new Vector3(40f, 0f, 0f) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        pickupEvent?.Invoke();
        gameObject.SetActive(false);
    }
}
