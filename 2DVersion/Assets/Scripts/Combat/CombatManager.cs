using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class CombatManager : MyManagerBehavior
{
      public static CombatManager Instance;
    public CombatState State;

    public GameObject currentCharacterTurn;


    public static event Action<GameObject> OnCharacterTurn;
    public static event Action<CombatState> OnCombatStateChanged;



    private void Awake()
    {
                Instance = this;
                
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;



    }
    private void CharacterEndTurn()
    {               currentCharacterTurn.GetComponent<PlayerCombat>().playerCombatHandler.OnEndTurn -= CharacterEndTurn;

        combatManagerData.TurnIncrease();
        UpdateCombatState(CombatState.DecideTurn);

    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;

    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        if (state == GameState.Combat)
        {
            // Build
            // set combat to acive

            // reset


            // ResetAllCombatData();
            //  ResetAllCombatUI();
            // reset classes
            // Make the builders reset then build

            // process round
             combatManagerData.InitializeAndFillSortedOrderListAndTurnOrderQueue();
             combatManagerData.AddCharacterInCombatToPlayerOrEnemyList();

            UpdateCombatState(CombatState.DecideTurn);


            // Loop
            // Wait Turn Completion
            // Check Wincon
            // NextTurn


            // EndCombat

        }

    }
    // characters sub to this and act on change

    public void UpdateCombatState(CombatState newState)
    {
        State = newState;
        switch (newState)
        {
            case CombatState.DecideTurn:
                DecideTurn();
                break;
            case CombatState.Victory:
                HandleVictory();
                break;

            case CombatState.Lose:
                HandleLose();
                break;
            case CombatState.NoCombat:
                break;
            default:
                break;
        }

        OnCombatStateChanged?.Invoke(newState);
    }

    private void DecideTurn()
    {
        if ( this.combatManagerData.DeathCheckEnemies())
        {
            Debug.Log("asa");
            UpdateCombatState(CombatState.Victory);

        }
        else if ( this.combatManagerData.DeathCheckPlayers())
        {
              Debug.Log("a222sa");
            UpdateCombatState(CombatState.Lose);
        }
        else
        {
              Debug.Log("nnnnnsa");
              
            combatManagerData.DequeueTurnOrder();
            currentCharacterTurn = combatManagerData.GetCurrentCharacterTurn();
        
            currentCharacterTurn.GetComponent<PlayerCombat>().playerCombatHandler.OnEndTurn += CharacterEndTurn;

            OnCharacterTurn?.Invoke(currentCharacterTurn);
        }

    }

    public void HandleVictory()
    {
        Debug.Log("Victory");

        UpdateCombatState(CombatState.NoCombat);


    }
    public void HandleLose()
    {
        Debug.Log("Lost");

        UpdateCombatState(CombatState.NoCombat);
    }

    public bool IsCombatStateNoCombat()
    {
        return (this.State == CombatState.NoCombat);
        
      
    }
    public enum CombatState
    {
        NoCombat,
        BuildingCombat,
        CombatHandlerState,
        DecideTurn,
        PlayerTurn,
        EnemyTurn,
        Victory,
        Lose,
        MidTurn

    }
}


