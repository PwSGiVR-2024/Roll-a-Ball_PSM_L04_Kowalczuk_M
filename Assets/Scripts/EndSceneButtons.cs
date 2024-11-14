using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneButtons : MonoBehaviour
{
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
