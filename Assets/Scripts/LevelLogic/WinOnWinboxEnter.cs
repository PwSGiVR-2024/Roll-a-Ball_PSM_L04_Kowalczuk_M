using UnityEngine;
using System;
public class WinOnWinboxEnter : LevelManager
{
    [SerializeField] private WinHitBox winHitBox;
    private void Start()
    {
        getGameManager();
        winHitBox.triggerEvent += winLevel;
    }
}
