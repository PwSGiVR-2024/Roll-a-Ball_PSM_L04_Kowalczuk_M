using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    public event Action playerDie;
    [SerializeField] private bool playerAllreadyDead = false;

    private void Start()
    {
        playerAllreadyDead = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("KillBox") && !playerAllreadyDead)
        {
            playerAllreadyDead = true;
            playerDie?.Invoke();
            Destroy(gameObject);
        }
    }
}
