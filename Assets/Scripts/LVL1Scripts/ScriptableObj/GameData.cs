using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public int playerHP;
    public int smallAsteroid;
    public int middleAsteroid;
    public int largeAsteroid;
    public int shipsDestroyed;
    public int survivedTime;

    public GameData(int playerHP)
    {
        this.playerHP = playerHP;
    }
}
