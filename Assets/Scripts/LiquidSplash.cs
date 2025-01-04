using UnityEngine;

public class LiquidSplash : MonoBehaviour
{
    [SerializeField] GameObject splashPrefab;
    private void OnTriggerEnter(Collider other)
    {
        GameObject particles = Instantiate(splashPrefab, other.transform.position, Quaternion.Euler(90f, 0f, 0f)); 
        particles.GetComponent<ParticleSystem>().Play();
    }
}
