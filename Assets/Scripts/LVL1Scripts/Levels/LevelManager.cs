using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DifficultSetup))]
public class LevelManager : MonoBehaviour
{
    public List<LevelInfo> stage1Levels;
    public LevelInfo currentLevel;
    public GameData gameData;
    public DialogManager dialogManager;
    public StartLevelMenuHandler startLevelMenuHandler;
    public EndLevelMenuHandler endLevelMenuHandler;


    public AsteroidCreator smallAsteroidsCreator;
    public AsteroidCreator middleAsteroidsCreator;
    public AsteroidCreator largeAsteroidsCreator;

    private DifficultSetup levelDifficultSetup;
    private string stage1LevelsPAth = "Stage1Levels";
    private string Stage1LvlProgressPref ="Stage1LevelProgress";


    private void Awake()
    {
        LoadStage1Levels();
        LoadLevelProgress();
       
    }

    private void Start()
    {
        levelDifficultSetup = GetComponent<DifficultSetup>();
        startLevelMenuHandler.ShowStartLevelMenu(currentLevel);
    }

    private void Update()
    {
        if (currentLevel.isLevelComplited(gameData)==true)
        {
            endLevelMenuHandler.ShowEndLevelMenu();
        }
    }

    public void StartAsteroidsCreation()
    {
        smallAsteroidsCreator.StartAsteroidsCreation();
        middleAsteroidsCreator.StartAsteroidsCreation();
        largeAsteroidsCreator.StartAsteroidsCreation();
    }

    public void SmallAsteroidDestroyed() 
    {
        gameData.smallAsteroid++;
    }

    public void MiddleAsteriodDestroyed()
    {
        gameData.middleAsteroid++;
    }

    public void LargeAsteroidDestroyed()
    {
        gameData.largeAsteroid++;
    }

    private void IncreaseSurviveTimer()
    {
        gameData.survivedTime++;
    }

    public void StartSurviveTimer()
    {
        InvokeRepeating("IncreaseSurviveTimer",1f,1f);
    }

    public void StopSurviveTimer()
    {
        CancelInvoke("IncreaseSurviveTimer");
        gameData.survivedTime = 0;
    }

    public void PlayerHPDecrease()
    {
        gameData.playerHP--;
    }

    public void StartLevel()
    {
        gameData = new GameData(3);
        levelDifficultSetup.SetupLevelDifficult(currentLevel.difficultRequirements);
        dialogManager.PlayDialog(currentLevel.startDialog);
        Debug.Log(currentLevel.difficultRequirements.smallAsteroidsPerSecond);
        Debug.Log(smallAsteroidsCreator.asteroidsPerSecond);
        StartAsteroidsCreation();
        StartSurviveTimer();
    }

    public void EndLevel()
    {
        endLevelMenuHandler.ShowEndLevelMenu();
    }

    private void LoadLevelProgress()
    {
        if (PlayerPrefs.HasKey(Stage1LvlProgressPref))
        {
            int levelProgress = PlayerPrefs.GetInt(Stage1LvlProgressPref);
            currentLevel = stage1Levels.Find(level => level.LevelNum == levelProgress);
            // Дальнейшая обработка загруженного прогресса уровня, если необходимо
        }
        else
        {
            // Ключ Stage1LvlProgressPref отсутствует в PlayerPrefs
            // Запуск игры с первого уровня сцены.
            PlayerPrefs.SetInt(Stage1LvlProgressPref, 1);
            currentLevel = stage1Levels.Find(level => level.LevelNum == 1);
        }
    }

    private void LoadStage1Levels()
    {
        Object[] stage1LevelsObj = Resources.LoadAll(stage1LevelsPAth, typeof(LevelInfo));
        foreach (Object obj in stage1LevelsObj)
        {
            stage1Levels.Add(obj as LevelInfo);
        }
    }

}
