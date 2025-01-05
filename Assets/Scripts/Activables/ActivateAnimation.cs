using UnityEngine;

public class ActivateAnimation : MonoBehaviour, IActivable
{
    [SerializeField] Animator animator;
    [SerializeField] string animatorTriggerName;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Activate()
    {
        animator.SetTrigger(animatorTriggerName);
        if(audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void Activate(float delay)
    {
        Invoke(nameof(Activate), delay);
    }
}
