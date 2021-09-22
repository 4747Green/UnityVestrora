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
        if (!processingAction & playerCombat.playerCombatHandler.GetAllowedToAct()){
            TakeAction(newState);
        }




    }
    private void TakeAction(ActionTypeState newState)
    {
        actionCost = 1;
        if (playerCombat.playerCombatHandler.AttackCall(1))
        {
            UpdateActionTypeState(newState);
        }
        else
        {
            
        }

    }
    public void UpdateActionTypeState(ActionTypeState newState)
    {
        State = newState;
        switch (newState)
        {
            case ActionTypeState.Neutral:
                break;
            case ActionTypeState.ActionTakenState:
                HandleActionTaken();
                break;
            case ActionTypeState.MeeleAttack:
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
