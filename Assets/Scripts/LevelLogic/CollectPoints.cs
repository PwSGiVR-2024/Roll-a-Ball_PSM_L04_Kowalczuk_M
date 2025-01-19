using UnityEngine;
using UnityEngine.Audio;

public class CollectPoints : MonoBehaviour, IWinCondition
{
    [SerializeField] int totalPointsNumber, pointsNumber = 0;
    [SerializeField] Collectible[] points;
    [SerializeField] TextWriter messageText;
    private bool condition;

    public bool checkCondition()
    {
        return condition;
    }

    private void SetUpParameters()
    {
        pointsNumber = 0;
        points = FindObjectsByType<Collectible>(FindObjectsSortMode.None);
        totalPointsNumber = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            points[i].GetComponent<Collectible>().pickupEvent += collectPoint;
        }
    }

    public void collectPoint()
    {
        pointsNumber++;
        messageText.writeText("Collected " + pointsNumber.ToString() + " out of " + totalPointsNumber.ToString());
        if (pointsNumber >= totalPointsNumber)
        {
            condition = true;
        }
    }

    void Awake()
    {
        condition = false;
    }
    private void Start()
    {
        SetUpParameters();
    }

}
