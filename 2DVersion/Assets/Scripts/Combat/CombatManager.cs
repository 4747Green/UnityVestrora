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

    public static event Action OnCharacterCallToEndTurn;
    public static event Action OnGameQueueUIReady;
    public static event Action<GameObject> OnCharacterTurn;
    public static event Action<CombatState> OnCombatStateChanged;
    // public static event Action<CombatState> OnCombatStateChanged;


    private void Awake()
    {
        Instance = this;

        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;



    }
    private void CharacterEndTurn()
    {
        currentCharacterTurn.GetComponent<PlayerCombat>().playerCombatHandler.OnEndTurn -= CharacterEndTurn;

        combatManagerData.TurnIncrease();
        UpdateCombatState(CombatState.DecideTurn);

    }

    private void CharacterDeath(GameObject character)
    {
        
        
        
        combatManagerData.RemoveFromCombat(character);
        OnGameQueueUIReady?.Invoke();
        character.GetComponent<PlayerClass>().OnDeath -= CharacterDeath;
        if (this.combatManagerData.DeathCheckEnemies())
        {
            OnCharacterCallToEndTurn?.Invoke();
            
            UpdateCombatState(CombatState.Victory);


        }
        else if (this.combatManagerData.DeathCheckPlayers())
        {
           
            OnCharacterCallToEndTurn?.Invoke();
            UpdateCombatState(CombatState.Lose);
        }
        else
        {

        }




    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;

    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        if (state == GameState.Combat)
        {
            combatManagerData.InitializeAndFillSortedOrderListAndTurnOrderQueue();
            combatManagerData.AddCharacterInCombatToPlayerOrEnemyList();
            SubscribeToCharactersInCombat();
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
                HandleNoCombat();
                break;
            default:
                break;
        }

        OnCombatStateChanged?.Invoke(newState);
    }
    private void HandleNoCombat(){

    }
    private void DecideTurn()
    {
        if (this.combatManagerData.DeathCheckEnemies())
        {

            UpdateCombatState(CombatState.Victory);

        }
        else if (this.combatManagerData.DeathCheckPlayers())
        {

            UpdateCombatState(CombatState.Lose);
        }
        else
        {

           
            combatManagerData.DequeueTurnOrder();
            currentCharacterTurn = combatManagerData.GetCurrentCharacterTurn();

            currentCharacterTurn.GetComponent<PlayerCombat>().playerCombatHandler.OnEndTurn += CharacterEndTurn;
            OnGameQueueUIReady?.Invoke();
            OnCharacterTurn?.Invoke(currentCharacterTurn);
        }

    }

    public void SubscribeToCharactersInCombat()
    {
        foreach (var item in combatManagerData.GetCharactersInCombat())
        {

            item.GetComponent<PlayerClass>().OnDeath += CharacterDeath;

        }
    }

    public void UnsubscribeToCharactersInCombat()
    {
        foreach (var item in combatManagerData.GetCharactersInCombat())
        {
            item.GetComponent<PlayerClass>().OnDeath -= CharacterDeath;

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


