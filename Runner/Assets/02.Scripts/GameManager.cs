using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameState gameState;

    public static void Play()
    {
        gameState = GameState.StartGame;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Update()
    {
        switch (gameState)
        {
            case global::GameState.Idle:
                break;
            case global::GameState.StartGame:
                break;
            case global::GameState.SpawnMap:
                break;
            case global::GameState.WaitForMapSpawned:
                break;
            case global::GameState.StartRun:
                break;
            case global::GameState.WaitForGameFinished:
                break;
            case global::GameState.Finish:
                break;
            default:
                break;
        }
    }

}

public enum GameState
{
    Idle,
    StartGame,
    SpawnMap,
    WaitForMapSpawned,
    StartRun,
    WaitForGameFinished,
    Finish,
}
