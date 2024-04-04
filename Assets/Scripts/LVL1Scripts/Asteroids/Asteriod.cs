using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod
{
    public int HitPoints;
}

public class SmallAsteroid : Asteriod
{
    public SmallAsteroid() 
    {
        HitPoints = 3;
    }
}