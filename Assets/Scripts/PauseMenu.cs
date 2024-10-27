using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuObject;

    void Start()
    {
        pauseMenuObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuObject.SetActive(!pauseMenuObject.activeSelf);
            Time.timeScale = (pauseMenuObject.activeSelf)? 0f : 1f;
        }
    }

    public void exitButton()
    {
        Application.Quit();
    }

    public void backToMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void backButton()
    {
        pauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
    }
        
}
