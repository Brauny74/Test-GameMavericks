using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level")]
public class Level : ScriptableObject
{
    public float RespawnCooldown;
    public int AmountOfMeteorsToWin;

    public enum LevelState { Locked, Unlocked, Beaten };
    public LevelState CurrentState = LevelState.Locked;

    public void Unlock()
    {
        CurrentState = LevelState.Unlocked;
    }

    public void Beat()
    {
        CurrentState = LevelState.Beaten;
    }
}
