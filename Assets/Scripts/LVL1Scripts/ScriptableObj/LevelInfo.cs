using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Level",menuName = "My Scriptables/Scenario/Scene1Levels")]
public class LevelInfo : ScriptableObject
{
    public int LevelNum;
    public int StageNum;
    public string levelName;
    public DialogInfo startDialog;
    public DialogInfo endDialog;

    public GameData levelRequirements;

    public LevelDifficultRequirements difficultRequirements;

    public bool isLevelComplited(GameData currentGameState)
    {
        return
            (levelRequirements.smallAsteroid == 0 || levelRequirements.smallAsteroid <= currentGameState.smallAsteroid) &&
            (levelRequirements.middleAsteroid == 0 || levelRequirements.middleAsteroid <= currentGameState.middleAsteroid) &&
            (levelRequirements.largeAsteroid == 0 || levelRequirements.largeAsteroid <= currentGameState.largeAsteroid) &&
            (levelRequirements.shipsDestroyed == 0 || levelRequirements.shipsDestroyed <= currentGameState.shipsDestroyed) &&
            (levelRequirements.survivedTime == 0 || levelRequirements.survivedTime <= currentGameState.survivedTime);
    }
}
