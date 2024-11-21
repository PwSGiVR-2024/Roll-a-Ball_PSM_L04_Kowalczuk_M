using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float bounceForce = 5f;
    public event Action trampolineEvent;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>())
        {
            trampolineEvent?.Invoke();
            collision.gameObject.GetComponent<Rigidbody>().AddForce(0f, bounceForce, 0f, ForceMode.Impulse);
        }
    }
}
