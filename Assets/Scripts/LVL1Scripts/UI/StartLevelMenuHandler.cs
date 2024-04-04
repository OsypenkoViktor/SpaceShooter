using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartLevelMenuHandler : MonoBehaviour
{
    public TextMeshProUGUI levelNumber;
    public TextMeshProUGUI levelName;
    public Button startLevelBtn;
    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowStartLevelMenu(LevelInfo levelInfo)
    {
        levelNumber.text = $"Stage {levelInfo.StageNum}. Level {levelInfo.LevelNum}";
        levelName.text = levelInfo.levelName;
        gameObject.SetActive(true);
    }

    public void StartGame()
    {
        levelManager.StartLevel();
        gameObject.SetActive(false);
    }
}
