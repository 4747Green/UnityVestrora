using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerCombatHandler
{
    // Start is called before the first frame update
    private bool turnInProcess = false;
    private bool myTurn = false;
    private bool actionTaken = false;
    private bool AllowedToAct = false;
    private int actionsEconomyOfPlayer;
    public int actionsEconomyThisTurn;
    public PlayerCombatState State;
    public PlayerCombat playerCombat;

    public event Action OnEndTurn;

    // Event Trigger From Combat Manager On NewTurn For all those in combat
    public void CombatManagerOnCharacterTurn(GameObject character)
    {
        if (character.GetComponent<PlayerCombat>() == playerCombat)
        {

            // if turn is in process proceed with turn
            if (!turnInProcess)
            {
                turnInProcess = true;
                UpdatPlayerCombatState(PlayerCombatState.SetUpPlayerTurn);

            }
            else
            {

            }
        }
    }

    public void OnEndturn()
    {
        
        OnEndTurn?.Invoke();

    }

    public void CancelTurn()
    {
        myTurn = false;
        actionTaken = true;
        actionsEconomyThisTurn = 0;
        AllowedToAct = false;
        turnInProcess = false;
        UpdatPlayerCombatState(PlayerCombatState.Neutral);
    }

    public PlayerCombatHandler(int actionEcon, PlayerCombat playerCombat)
    {
        CombatManager.OnCharacterTurn += CombatManagerOnCharacterTurn;
        CombatManager.OnCharacterCallToEndTurn += CancelTurn;

        actionsEconomyOfPlayer = actionEcon;
        this.playerCombat = playerCombat;
        UpdatPlayerCombatState(PlayerCombatState.Neutral);


    }



    // to do
    public bool ThisCharacterDead()
    {
        return false;
    }
    public bool CombatOverConditionTriggered()
    {
        return false;

    }

    public void UpdatPlayerCombatState(PlayerCombatState newState)
    {
        State = newState;
        switch (newState)
        {
            case PlayerCombatState.Neutral:
               
                break;
            case PlayerCombatState.SetUpPlayerTurn:

                SetUpPlayerTurn();
                break;
            case PlayerCombatState.CheckIfTurnIsOver:
               
                CheckIfTurnIsOver();
                break;
            case PlayerCombatState.MyTurn:
                
                HandleMyTurn();
                break;

            case PlayerCombatState.SetUpPlayerEndTurn:
               
                SetUpPlayerEndTurn();
                break;

            case PlayerCombatState.EndTurn:
                
                HandleEndTurn();
                break;
            default:
                break;
        }

        //   OnGameStateChanged?.Invoke(newState);
    }
    private void HandleMyTurn()
    {
        

        AllowedToAct = true;
        if (!playerCombat.IsHeroPlayer())
        {
            playerCombat.EnemyTurn();
        }

    }
    private void SetUpPlayerEndTurn()
    {
        myTurn = false;
        actionTaken = true;
        actionsEconomyThisTurn = 0;
        AllowedToAct = false;
        UpdatPlayerCombatState(PlayerCombatState.EndTurn);
    }
    private void SetUpPlayerTurn()
    {

        myTurn = true;
        actionTaken = false;
        actionsEconomyThisTurn = actionsEconomyOfPlayer;


        UpdatPlayerCombatState(PlayerCombatState.CheckIfTurnIsOver);

    }
    public void HandleEndTurn()
    {
        turnInProcess = false;
        UpdatPlayerCombatState(PlayerCombatState.Neutral);
        //   CombatHandler.Instance.UpdateCombatState(CombatHandler.CombatState.Decider);
        OnEndturn();

    }
    public bool GetTurnInProcess()
    {
        return turnInProcess;
    }
    public void CheckIfTurnIsOver()
    {
        AllowedToAct = false;

        if (!DoesCharacterHaveActionsLeft())
        {

            UpdatPlayerCombatState(PlayerCombatState.SetUpPlayerEndTurn);

        }
        else
        {

            UpdatPlayerCombatState(PlayerCombatState.MyTurn);

        }



    }
    public enum PlayerCombatState
    {
        Neutral,
        SetUpPlayerTurn,
        CheckIfTurnIsOver,
        MyTurn,
        SetUpPlayerEndTurn,
        EndTurn,



    }

    public bool GetAllowedToAct()
    {
        return AllowedToAct;
    }
    public bool DoesCharacterHaveActionsLeft()
    {
        return (actionsEconomyThisTurn > 0);

    }
    public bool AttackCall(int actionEconomyCost)
    {
        return ((actionsEconomyThisTurn - actionEconomyCost) >= 0);


    }
    public void ActionTaken(int actionEconomyCost)
    {
      
        actionTaken = true;
        actionsEconomyThisTurn = actionsEconomyThisTurn - actionEconomyCost;
       
        if(myTurn){
            UpdatPlayerCombatState(PlayerCombatState.CheckIfTurnIsOver);
        }else{

        }
        
    }

}
