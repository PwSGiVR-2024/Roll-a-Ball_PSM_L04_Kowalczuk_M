using UnityEngine;
using System.Collections.Generic;

public class WinOnWinboxWithConditions : LevelManager
{
    [SerializeField] private WinHitBox winHitBox;
    [SerializeField] private List<IWinCondition> winConditions;
    [SerializeField] private List<GameObject> winConditionsObjects;
    private void Start()
    {
        getGameManager();
        winHitBox.triggerEvent += checkConditions;
        winConditions = new List<IWinCondition>();
        for(int i = 0; i < winConditionsObjects.Count; i++)
        {
            if(winConditionsObjects[i].GetComponent<IWinCondition>() != null)
            {
                winConditions.Add(winConditionsObjects[i].GetComponent<IWinCondition>());
            }
        }
    }

    private void checkConditions()
    {
        bool flag = true;
        for(int i = 0; i < winConditions.Count; i++)
        {
            if(!winConditions[i].checkCondition())
            {
                flag = false;
                break;
            }
        }
        if(flag)
        {
            winLevel();
        }
    }
}
