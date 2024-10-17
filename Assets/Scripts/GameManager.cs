using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] int totalPointsNumber;
    [SerializeField] Collectible[] points;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        points = GameObject.FindObjectsOfType<Collectible>();
        totalPointsNumber = points.Length;
    }

    public void getCollectedPoints (int n)
    {
        if (n >= totalPointsNumber)
        {
            Debug.Log("All points collected!");
        }
    }

}
