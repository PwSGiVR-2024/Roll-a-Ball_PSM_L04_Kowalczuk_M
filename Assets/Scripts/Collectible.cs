using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(20f, 20f, 20f) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        other.gameObject.GetComponent<MovementController>().collectCollectible();
    }
}
