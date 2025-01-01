using UnityEngine;

public class ActivateSetActive : MonoBehaviour, IActivable
{
    [SerializeField] bool mode;

    private void Awake()
    {
        gameObject.SetActive(!mode);
    }
    public void Activate()
    {
        gameObject.SetActive(mode);
    }

    public void Activate(float delay)
    {
        Invoke(nameof(Activate), delay);
    }
}
