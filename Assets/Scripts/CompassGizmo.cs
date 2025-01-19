using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class CompassGizmo : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 playerToGizmoVector, movementForce;
    [SerializeField] Rigidbody playerRB;
    [SerializeField] List<Transform> coins;
    [SerializeField]
    Vector3 closestCoinPosition;
    [SerializeField]
    float distance;

    private void Start()
    {
        Debug.Log("enabled");
        Collectible[] points;
        points = FindObjectsByType<Collectible>(FindObjectsSortMode.None);
        for (int i = 0; i < points.Length; i++)
        {
            points[i].pickupEvent += updateCoinList;
            coins.Add(points[i].transform);
        }
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerRB = playerTransform.GetComponent<Rigidbody>();
        playerToGizmoVector = transform.position - playerTransform.position;
    }

    void updateCoinList()
    {
        for (int i = 0; i < coins.Count; i++)
        {
            if (!coins[i].gameObject.activeSelf)
            {
                coins.RemoveAt(i);
                break;
            }
        }
        if (!coins.Any())
        {
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (coins.Any())
        {
            closestCoinPosition = coins[0].position;
            distance = Vector3.Distance(coins[0].position, transform.position);
            for (int i = 1; i < coins.Count; i++)
            {
                if(distance > Vector3.Distance(transform.position, coins[i].position))
                {
                    distance = Vector3.Distance(transform.position, coins[i].position);
                    closestCoinPosition = coins[i].position;
                }
            }
            //transform.Rotate(0f, Vector3.Angle(transform.position, closestCoinPosition), 0f);
            transform.LookAt(closestCoinPosition);
        }
        transform.position = playerTransform.position + playerToGizmoVector;
    }
}
