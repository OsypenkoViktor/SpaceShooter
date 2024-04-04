using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelMenuHandler : MonoBehaviour
{    
    public void ShowEndLevelMenu()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }
}
