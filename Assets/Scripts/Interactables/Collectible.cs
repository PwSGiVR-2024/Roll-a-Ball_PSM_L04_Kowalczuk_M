using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Collectible : MonoBehaviour, IIneractable
{
    private List<Tools.Activable> activables;
    [SerializeField] private List<Tools.ActivableObject> activableObjects;

    public event Action pickupEvent;

    private void Awake()
    {
        activables = new List<Tools.Activable>();
    }
    private void Start()
    {
        if (activableObjects != null)
        {
            for (int i = 0; i < activableObjects.Count; i++)
            {
                if (activableObjects[i].activableObject.GetComponent<IActivable>() != null)
                {
                    //Debug.Log(activableObjects[i].activableObject.GetComponent<IActivable>());
                    //Debug.Log(activableObjects[i].delay);
                    activables.Add(new Tools.Activable(activableObjects[i].delay, activableObjects[i].activableObject.GetComponent<IActivable>()));
                }
                else
                {
                    Debug.Log("No IActivable script in object of index " + i);
                }
            }
        }
    }

    public void Interact()
    {
        for (int i = 0; i < activables.Count; i++)
        {
            activables[i].activable.Activate(activables[i].delay);
        }
        gameObject.SetActive(false);
        pickupEvent?.Invoke();
    }
}
