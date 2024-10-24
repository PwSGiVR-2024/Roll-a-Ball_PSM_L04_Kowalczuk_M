using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] int totalPointsNumber, pointsNumber;
    [SerializeField] Collectible[] points;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject winText;

    private void Awake()
    {
        winText.SetActive(false);
        Instance = this;
    }

    void Start()
    {
        pointsNumber = 0;
        points = GameObject.FindObjectsOfType<Collectible>();
        totalPointsNumber = points.Length;
        scoreText.text = "Score: " + pointsNumber.ToString();
    }

    public void getCollectedPoints (int n)
    {
        pointsNumber = n;
        scoreText.text = "Score: " + pointsNumber.ToString();
        if (pointsNumber >= totalPointsNumber)
        {
            winText.SetActive(true);
            //Debug.Log("All points collected!");
            Debug.Log(SceneManager.GetActiveScene().buildIndex + " " + (SceneManager.sceneCountInBuildSettings - 1));
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

}
