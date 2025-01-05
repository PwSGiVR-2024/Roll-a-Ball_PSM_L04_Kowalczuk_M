using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    public event Action playerDie;
    [SerializeField] private bool playerAllreadyDead = false;
    [SerializeField] private GameObject particlesPrefab;
    public void killPlayer()
    {
        playerDie?.Invoke();
    }
    private void Awake()
    {
        playerAllreadyDead = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("KillBox") && !playerAllreadyDead)
        {
            GameObject _particles = Instantiate(particlesPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f));
            _particles.GetComponent<ParticleSystem>().Play();
            playerAllreadyDead = true;
            playerDie?.Invoke();
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Interactable") && !playerAllreadyDead)
        {
            if(other.GetComponent<IIneractable>() != null)
            {
                other.GetComponent<IIneractable>().Interact();
            }
            else
            {
                Debug.Log("Object " + other.gameObject.name + " doesn't have IInteractable compennent");
            }
        }
    }
}
