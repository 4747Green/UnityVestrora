using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MyManagerBehavior
{
    public static GameManager Instance;
    public static event Action<GameState> OnGameStateChanged;
    public GameState State;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UpdateGameState(GameState.FreeRoam);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.FreeRoam:
                HandleFreeRoamState();
                break;
            case GameState.Dialouge:
                HandleDialougeGameState();
                break;

            case GameState.Victory:
                HandleVictoryGameState();
                break;
            case GameState.Combat:
                StartCombat();
                break;

            case GameState.Lose:
                HandleLoseGameState();
                break;

            default:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }



    private void HandleFreeRoamState()
    {
        UIManager.Instance.FreeRoamState();
    }

    private void StartCombat()
    {
        if(this.State != GameState.Combat){
            UpdateGameState(GameState.Combat);
        }
        

    }


    private void HandleVictoryGameState()
    {
        Debug.Log("Victory");
     
        UpdateGameState(GameState.FreeRoam);
    }

    private void HandleLoseGameState()
    {
        Debug.Log("Lost");
       
        UpdateGameState(GameState.FreeRoam);
    }
    private void HandleDialougeGameState()
    {
        if (UIManager.Instance.dialogueHandler.isComplete)
        {
            UIManager.Instance.DialogueState();

        }

    }
}


public enum GameState
{
    FreeRoam,
    Combat,
    Victory,
    Lose,
    Dialouge
}

