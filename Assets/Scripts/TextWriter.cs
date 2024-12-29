using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TextWriter : MonoBehaviour
{
    [SerializeField] TMP_Text messageText;
    [SerializeField] int textQueue = 0;

    private void Avake()
    {
        textQueue = 0;
        messageText.enabled = false;
        SceneManager.activeSceneChanged += resetQueue;
    }

    private void resetQueue(Scene scene1, Scene scene2)
    {
        textQueue = 0;
    }
    public void writeText(string text)
    {
        messageText.text = text;
        messageText.enabled = true;
        textQueue++;
    }

    public void writeText(string text, int time)
    {
        messageText.text = text;
        messageText.enabled = true;
        textQueue++;
        Debug.Log("write " + textQueue);
        Invoke(nameof(hideText), time);
    }

    public void hideText()
    {
        Debug.Log("hide " + textQueue);
        if (textQueue <= 1)
        {
            messageText.enabled = false;
            textQueue = 0;
        }
        else
        {
            textQueue--;
        }
    }
}
