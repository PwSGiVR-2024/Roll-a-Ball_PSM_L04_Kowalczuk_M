using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaver : MonoBehaviour, IIneractable
{
    private List<Tools.Activable> activables;
    [SerializeField] private List<Tools.ActivableObject> activableObjects;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        activables = new List<Tools.Activable>();
    }
    private void Start()
    {
        if (activableObjects != null)
        {
            for(int i = 0; i < activableObjects.Count; i++)
            {
                if(activableObjects[i].activableObject.GetComponent<IActivable>() != null)
                {
                    //Debug.Log(activableObjects[i].activableObject.GetComponent<IActivable>());
                    //Debug.Log(activableObjects[i].delay);
                    activables.Add(new Tools.Activable( activableObjects[i].delay, activableObjects[i].activableObject.GetComponent<IActivable>()));
                }
                else
                {
                    Debug.Log("No IActivable script in object of index " + i);
                }
            }
        }
    }

    private void onLeverFinish()
    {
        for(int i = 0; i < activables.Count; i++)
        {
            activables[i].activable.Activate(activables[i].delay);
        }
    }
    void IIneractable.Interact()
    {
        animator.SetTrigger("Pull");
    }
}
