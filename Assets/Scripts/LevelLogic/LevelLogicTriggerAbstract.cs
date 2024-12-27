using UnityEngine;
using System;

public abstract class LevelLogicTriggerAbstract : MonoBehaviour
{
    public abstract event Action triggerEvent;
}
