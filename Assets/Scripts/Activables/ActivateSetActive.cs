using UnityEngine;
using UnityEngine.Audio;

public class ActivateSetActive : MonoBehaviour, IActivable
{
    [SerializeField] bool mode;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        gameObject.SetActive(!mode);
    }
    public void Activate()
    {
        gameObject.SetActive(mode);
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void Activate(float delay)
    {
        Invoke(nameof(Activate), delay);
    }
}
