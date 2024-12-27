using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameManager gameManager;

    public void getGameManager()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void winLevel()
    {
        gameManager.nextScene();
    }
}
