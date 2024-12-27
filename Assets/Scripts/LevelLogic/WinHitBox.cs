using System;
using UnityEngine;

public class WinHitBox : MonoBehaviour
{
    public event Action triggerEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            triggerEvent();
        }
    }
}
