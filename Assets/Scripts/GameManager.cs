using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] int totalPointsNumber, pointsNumber = 0;
    [SerializeField] Collectible[] points;
    [SerializeField] Trampoline[] trampolines;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject winText;
    [SerializeField] AudioClip coinSound, trampolineSound;
    AudioSource audioSource;
    private void Awake()
    {
        winText.SetActive(false);
        Instance = this;
    }

    void Start()
    {
        pointsNumber = 0;
        points = FindObjectsByType<Collectible>(FindObjectsSortMode.None);
        trampolines = FindObjectsByType<Trampoline>(FindObjectsSortMode.None);
        audioSource = GetComponent<AudioSource>();
        totalPointsNumber = points.Length;
        for(int i = 0; i < points.Length; i++)
        {
            points[i].GetComponent<Collectible>().pickupEvent += collectPoint;
        }
        for (int i = 0; i < trampolines.Length; i++)
        {
            trampolines[i].GetComponent<Trampoline>().trampolineEvent += trampolineJump;
        }
        scoreText.text = "Score: " + pointsNumber.ToString();
    }

    public void trampolineJump()
    {
        audioSource.resource = trampolineSound;
        audioSource.Play();
    }
    public void collectPoint()
    {
        audioSource.resource = coinSound;
        audioSource.Play();
        pointsNumber++;
        scoreText.text = "Score: " + pointsNumber.ToString();
        if (pointsNumber >= totalPointsNumber)
        {
            winText.SetActive(true);
            //Debug.Log("All points collected!");
            Debug.Log(SceneManager.GetActiveScene().buildIndex + " " + (SceneManager.sceneCountInBuildSettings - 1));
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                Invoke(nameof(nextScene), 3f);
            }
        }
    }

    private void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
