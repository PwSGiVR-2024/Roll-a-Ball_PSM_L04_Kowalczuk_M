using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public event Action pickupEvent;

    private void Update()
    {
        transform.Rotate(new Vector3(20f, 20f, 20f) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        pickupEvent?.Invoke();
        gameObject.SetActive(false);
    }
}
