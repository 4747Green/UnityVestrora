using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerCombatHandler
{
    // Start is called before the first frame update
    private bool turnInProcess = false;
    public bool inCombat = false;
    private bool myTurn = false;
    private bool actionTaken = false;
    private bool AllowedToAct = false;
    private int actionsEconomyOfPlayer;
    public int actionsEconomyThisTurn;
    public PlayerCombatState State;
    public PlayerCombat playerCombat;


    public GameObject myCharacter;
    public event Action OnEndTurn;



    public void CombatManagerOnCharacterTurn(GameObject character){
        Debug.Log("here");
        if(character.GetComponent<PlayerCombat>() == playerCombat){
                    Debug.Log("inside");

            HandleCallForCharacterTurn();
        }
    }
    public void OnEndturn()
    {

        OnEndTurn?.Invoke();

    }


    public PlayerCombatHandler(int actionEcon, PlayerCombat playerCombat)
    {
         CombatManager.OnCharacterTurn += CombatManagerOnCharacterTurn;

        actionsEconomyOfPlayer = actionEcon;
        this.playerCombat = playerCombat;
        UpdatPlayerCombatState(PlayerCombatState.Neutral);
     

    }




    public void HandleCallForCharacterTurn()
    {                    Debug.Log("2");

        if (!turnInProcess)
        {                    Debug.Log("333");

            turnInProcess = true;
            UpdatPlayerCombatState(PlayerCombatState.SetUpPlayerTurn);

        }
        else
        {

        }

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
                Debug.Log("1");
                break;
            case PlayerCombatState.SetUpPlayerTurn:
                Debug.Log("2");
                SetUpPlayerTurn();
                break;
            case PlayerCombatState.CheckIfTurnIsOver:
                Debug.Log("3");
                CheckIfTurnIsOver();
                break;
            case PlayerCombatState.MyTurn:
                Debug.Log("4");
                HandleMyTurn();
                break;

            case PlayerCombatState.SetUpPlayerEndTurn:
                Debug.Log("5");
                SetUpPlayerEndTurn();
                break;

            case PlayerCombatState.EndTurn:
                Debug.Log("6");
                HandleEndTurn();
                break;
            default:
                break;
        }

        //   OnGameStateChanged?.Invoke(newState);
    }
    private void HandleMyTurn()
    {
        Debug.Log(actionsEconomyThisTurn + " and " + actionsEconomyOfPlayer);

        AllowedToAct = true;
        if(!playerCombat.IsHeroPlayer()){
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
        Debug.Log("setting up");
        myTurn = true;
        actionTaken = false;
        Debug.Log(actionsEconomyThisTurn + " and " + actionsEconomyOfPlayer);
        actionsEconomyThisTurn = actionsEconomyOfPlayer;
        Debug.Log(actionsEconomyThisTurn + " and " + actionsEconomyOfPlayer);

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
        Debug.Log("Checking if turn over");

        AllowedToAct = false;
  //      CombatHandler.Instance.UpdateCombatState(CombatHandler.CombatState.Decider);



        
            if (!DoesCharacterHaveActionsLeft())
            {
                Debug.Log("no actions left ending turn ");

                UpdatPlayerCombatState(PlayerCombatState.SetUpPlayerEndTurn);

            }
            else
            {
                Debug.Log(actionsEconomyThisTurn + " and " + actionsEconomyOfPlayer);

                Debug.Log("Turn not over");

                UpdatPlayerCombatState(PlayerCombatState.MyTurn);

            }
        


    }
    public void CharacterTurnSetUP()
    {
        actionTaken = false;
        myTurn = true;
    }

    // Update stats for turn

    //loop
    // Update to myTurn
    // Update to check if myturn over after each action
    //loop

    // update stats for turn ended
    // end turn
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
        Debug.Log(actionsEconomyThisTurn);
        return ((actionsEconomyThisTurn - actionEconomyCost) >= 0);


    }
    public void ActionTaken(int actionEconomyCost)
    {
        actionTaken = true;
        actionsEconomyThisTurn = actionsEconomyThisTurn - actionEconomyCost;
        UpdatPlayerCombatState(PlayerCombatState.CheckIfTurnIsOver);
    }

}
