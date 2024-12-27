using UnityEngine;
using System;
public class Level0 : LevelManager
{
    [SerializeField] private WinHitBox winHitBox;
    private void Start()
    {
        getGameManager();
        winHitBox.triggerEvent += winLevel;
    }
}
