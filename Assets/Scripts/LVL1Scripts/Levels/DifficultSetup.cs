using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultSetup : MonoBehaviour
{
    public AsteroidCreator smallAsteroidsCreator;
    public AsteroidCreator middleAsteroidsCreator;
    public AsteroidCreator largeAsteroidsCreator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupLevelDifficult(LevelDifficultRequirements levelDifficultRequirements)
    {
        smallAsteroidsCreator.asteroidsPerSecond = levelDifficultRequirements.smallAsteroidsPerSecond;
        smallAsteroidsCreator.asteroidSpeed = levelDifficultRequirements.asteroidsSpeed;
        middleAsteroidsCreator.asteroidsPerSecond = levelDifficultRequirements.middleAsteroidsPerSecond;
        middleAsteroidsCreator.asteroidSpeed = levelDifficultRequirements.asteroidsSpeed;
        largeAsteroidsCreator.asteroidsPerSecond = levelDifficultRequirements.largeAsteroidsPerSecond;
        largeAsteroidsCreator.asteroidSpeed = levelDifficultRequirements.asteroidsSpeed;
    }
}
