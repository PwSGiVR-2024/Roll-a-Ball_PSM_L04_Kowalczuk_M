using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float fallLevel = -1;

    private async void Start()
    {
        await playerOffMapChceck();
    }

    public async Task playerOffMapChceck()
    {
        while (playerTransform != null) 
        {

            if (playerTransform.position.y <= fallLevel)
            {
                playerTransform.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                playerTransform.position = transform.position;
            }
            await Awaitable.WaitForSecondsAsync(5);
        }
    }

    //private void Update()
    //{
    //    if(playerTransform.position.y <= fallLevel)
    //    {
    //        playerTransform.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
    //        playerTransform.position = transform.position;
    //    }
    //}
}
