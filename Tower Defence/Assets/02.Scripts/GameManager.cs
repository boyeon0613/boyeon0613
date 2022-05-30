using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }
    public static void LoadSceneByName(string sceneName)
    {
        Scene targetScene = SceneManager.GetSceneByName(sceneName);
      
        
            SceneManager.LoadScene(sceneName);
        
    }
}
public enum GameState
{
    GameStage,
    Idle,
    SelectLevel,
    StartLevel,
    WaitForLevelFinished,
    CompleteLevel,
    FailLevel,
    GameFinished
}
