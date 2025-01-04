using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    //[SerializeField] int totalPointsNumber, pointsNumber = 0;
    //[SerializeField] Collectible[] points;
    [SerializeField] Trampoline[] trampolines;
    //[SerializeField] TMP_Text scoreText;
    //[SerializeField] GameObject winText;
    [SerializeField] AudioClip coinSound, trampolineSound;
    [SerializeField] AudioSource audioSource, musicSource;
    [SerializeField] TextWriter messageText;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float fallLevel = -6f;

    private async void startPlayerOffMapCheck()
    {
        await playerOffMapChceck(SceneManager.GetActiveScene().buildIndex);
    }

    public async Task playerOffMapChceck(int index)
    {
        while (playerTransform != null && index == SceneManager.GetActiveScene().buildIndex)
        {
            if (playerTransform.position.y <= fallLevel)
            {
                playerTransform.GetComponent<PlayerCollision>().killPlayer();
            }
            await Awaitable.WaitForSecondsAsync(5);
        }
    }
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
        PlayerCollision _player = FindFirstObjectByType<PlayerCollision>();
        if(_player != null)
        {
            _player.playerDie -= levelFailed;
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
        if (FindFirstObjectByType<PlayerCollision>())
        {
            playerTransform = FindFirstObjectByType<PlayerCollision>().transform;
            FindFirstObjectByType<PlayerCollision>().playerDie += levelFailed;
        }
        startPlayerOffMapCheck();
        //audioSource = FindAnyObjectByType<AudioSource>();
        //winText.SetActive(false);
        //pointsNumber = 0;
        //points = FindObjectsByType<Collectible>(FindObjectsSortMode.None);
        trampolines = FindObjectsByType<Trampoline>(FindObjectsSortMode.None);
        audioSource = GetComponent<AudioSource>();
        musicSource = GetComponentInChildren<AudioSource>();
        messageText = GetComponentInChildren<TextWriter>();
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
        messageText.writeText("YOU DIED", 3);
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
