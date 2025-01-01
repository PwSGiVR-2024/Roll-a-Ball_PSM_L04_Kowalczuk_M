using UnityEngine;

public class ActivateParticles : MonoBehaviour, IActivable
{
    [SerializeField] private ParticleSystem particles;

    private void Awake()
    {
        particles = GetComponent<ParticleSystem>();
    }
    public void Activate()
    {
        particles.Play();
    }

    public void Activate(float delay)
    {
        Invoke(nameof(Activate), delay);
    }
}
