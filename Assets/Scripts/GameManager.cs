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
    //[SerializeField] int totalPointsNumber, pointsNumber = 0;
    //[SerializeField] Collectible[] points;
    [SerializeField] Trampoline[] trampolines;
    //[SerializeField] TMP_Text scoreText;
    //[SerializeField] GameObject winText;
    [SerializeField] AudioClip coinSound, trampolineSound;
    [SerializeField] AudioSource audioSource;
    private void Awake()
    {
        //winText.SetActive(false);
        int gameStatus = FindObjectsByType<GameManager>(FindObjectsSortMode.None).Length;
        if (gameStatus > 1) 
        { 
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        SceneManager.activeSceneChanged += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneLoaded;
        //for (int i = 0; i < points.Length; i++)
        //{
        //    points[i].GetComponent<Collectible>().pickupEvent -= collectPoint;
        //}
        for (int i = 0; i < trampolines.Length; i++)
        {
            trampolines[i].GetComponent<Trampoline>().trampolineEvent -= trampolineJump;
        }
        Destroy(gameObject);
    }

    void OnSceneLoaded(Scene scene1, Scene scene2)
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 && SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount - 1)
        {
            Destroy(gameObject);
        }
        SetUpParameters();
    }
    void SetUpParameters()
    {
        FindFirstObjectByType<PlayerCollision>().playerDie += levelFailed;
        audioSource = FindAnyObjectByType<AudioSource>();
        //winText.SetActive(false);
        //pointsNumber = 0;
        //points = FindObjectsByType<Collectible>(FindObjectsSortMode.None);
        trampolines = FindObjectsByType<Trampoline>(FindObjectsSortMode.None);
        audioSource = GetComponent<AudioSource>();
        //totalPointsNumber = points.Length;
        //for(int i = 0; i < points.Length; i++)
        //{
        //    points[i].GetComponent<Collectible>().pickupEvent += collectPoint;
        //}
        for (int i = 0; i < trampolines.Length; i++)
        {
            trampolines[i].GetComponent<Trampoline>().trampolineEvent += trampolineJump;
        }
        //scoreText.text = "Score: " + pointsNumber.ToString();
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
        //pointsNumber++;
        //scoreText.text = "Score: " + pointsNumber.ToString();
        //if (pointsNumber >= totalPointsNumber)
        //{
        //    winText.SetActive(true);
        //    Debug.Log("All points collected!");
        //    Debug.Log(SceneManager.GetActiveScene().buildIndex + " " + (SceneManager.sceneCountInBuildSettings - 1));
        //    if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        //    {
        //        Invoke(nameof(nextScene), 3f);
        //    }
        //}
    }

    public void levelFailed()
    {
        FindFirstObjectByType<PlayerCollision>().playerDie -= levelFailed;
        Invoke(nameof(reloadLevel), 3f);
    }

    private void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
