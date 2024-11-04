using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    enum optionsToConfirm { none = 0, exit, backToMenu };
    [SerializeField] private GameObject pauseMenuObject;
    [SerializeField] private optionsToConfirm optionToConfirm = 0;

    void Start()
    {
        pauseMenuObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuObject.SetActive(!pauseMenuObject.activeSelf);
            Time.timeScale = (pauseMenuObject.activeSelf) ? 0f : 1f;
        }
    }

    public void confirmOperation()
    {
        switch (optionToConfirm)
        {
            case optionsToConfirm.exit:
                Application.Quit();
                break;
            case optionsToConfirm.backToMenu:
                Time.timeScale = 1f;
                SceneManager.LoadScene(0);
                break;
            default:
                break;
        }
    }

    public void exitButton()
    {
        optionToConfirm = optionsToConfirm.exit;
    }

    public void backToMenuButton()
    {
        optionToConfirm = optionsToConfirm.backToMenu;
    }

    public void backButton()
    {
        pauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
    }

}
