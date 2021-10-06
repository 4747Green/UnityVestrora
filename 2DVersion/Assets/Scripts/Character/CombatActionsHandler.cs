using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CombatActionsHandler
{
    // Start is called before the first frame update

    public PlayerCombat playerCombat;
    public ActionTypeState State;
    private int actionCost;
    private bool processingAction;
    public CombatActionsHandler(PlayerCombat playerCombat)
    {
        this.playerCombat = playerCombat;
        UpdateActionTypeState(ActionTypeState.Neutral);

    }

    public void CombatActionCall(ActionTypeState newState)
    {
        Debug.Log("CAH got call");
        if (processingAction)
        {
            Debug.Log("CAH call while processingAction");
        }
        else
        {
            TakeAction(newState);
        }
        // if(playerCombat.playerCombatHandler.GetAllowedToAct())




    }
    private void TakeAction(ActionTypeState newState)
    {
        Debug.Log("Taking Action");
        // code here to get cost of actions
        actionCost = 1;

        if (playerCombat.playerCombatHandler.AttackCall(1))
        {
            Debug.Log("Action allowed");
            UpdateActionTypeState(newState);
        }
        else
        {
            Debug.Log("Action costs too much");
        }

    }
    public void UpdateActionTypeState(ActionTypeState newState)
    {
        State = newState;
        switch (newState)
        {
            case ActionTypeState.Neutral:
                //        HandlePlayerDeciderState();
                Debug.Log("nat");
                break;
            case ActionTypeState.ActionTakenState:
                Debug.Log("action being taken state");
                HandleActionTaken();
                break;
            case ActionTypeState.MeeleAttack:
                Debug.Log("ma");
                AttackRollaAainstArmorClass();
                processingAction = false;
                UpdateActionTypeState(ActionTypeState.ActionTakenState);

                break;
            case ActionTypeState.RangeAttack:
                //        HandlePlayerDeciderState();
                break;
            case ActionTypeState.TouchAttack:
                //        HandleMyTurn();
                break;

            case ActionTypeState.Spell:
                //         HandlePlayerTurnEndedState();
                break;

            case ActionTypeState.Power:
                //       HandleNoCombat();
                break;
            case ActionTypeState.MoveAction:
                //       HandleNoCombat();
                break;
            default:
                break;
        }

        //   OnGameStateChanged?.Invoke(newState);
    }

    public void HandleActionTaken()
    {
        this.playerCombat.playerCombatHandler.ActionTaken(actionCost);
    }
    public void AttackRollaAainstArmorClass()
    {
        int damageRoll;
        int attackRoll = playerCombat.player.playerClassController.AttackRoll(false);
        if (attackRoll >= playerCombat.targetedEnemy.GetComponent<PlayerClass>().GetAC())
        {
            damageRoll = playerCombat.player.playerClassController.DamageRoll(false);
            Debug.Log("Attack of " + attackRoll + " Hits, Dealing " + damageRoll + " damage.");

            playerCombat.targetedEnemy.GetComponent<PlayerClass>().TakeDamage(damageRoll);
        }
        else
        {
            Debug.Log("Attack of " + attackRoll + " Misses");


        }
    }


    public enum ActionTypeState
    {
        Neutral,
        ActionTakenState,
        MeeleAttack,
        RangeAttack,
        TouchAttack,
        Spell,
        Power,
        MoveAction

    }




}
