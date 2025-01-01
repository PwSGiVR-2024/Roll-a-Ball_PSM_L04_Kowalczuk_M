using UnityEngine;

public class ActivateAnimation : MonoBehaviour, IActivable
{
    [SerializeField] Animator animator;
    [SerializeField] string animatorTriggerName;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Activate()
    {
        animator.SetTrigger(animatorTriggerName);
    }

    public void Activate(float delay)
    {
        Invoke(nameof(Activate), delay);
    }
}
