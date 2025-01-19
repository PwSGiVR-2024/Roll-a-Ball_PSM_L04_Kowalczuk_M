using UnityEngine;

public class HideRoof : MonoBehaviour
{
    [SerializeField] GameObject roof;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            roof.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            roof.SetActive(true);
        }
    }
}
