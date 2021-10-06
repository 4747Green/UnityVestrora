using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CombatManagerFix : MonoBehaviour
{
    //public static CombatManagerFix Instance;
    private GameObject currentCharacterTurn;
    public CombatHolderForManager combatHolder;
    public int numberOfTurnsToQueueFor;
    public int turnCounter = 0;
    private int round = 1;
    private int turnsInAround;
    
    private void Awake()
    {
      //  Instance = this;

    }



    public bool CheckIfQueueRequireRefill()
    {
        if (combatHolder.GetTurnOrderQueue().Count < (turnsInAround * (numberOfTurnsToQueueFor - round)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool isCurrentCharacterTurnAPlayer()
    {
        return currentCharacterTurn.GetComponent<PlayerCombat>().IsHeroPlayer();
    }
    public bool IsCharacterAPlayer(GameObject character)
    {
        return character.GetComponent<PlayerCombat>().IsHeroPlayer();
    }


    public void BeginCombat()
    {
        ResetRoundCounter();
        ResetTurnCounter();
        combatHolder.FillSortedTurnOrderList();
        SetTurnsInRound();
        combatHolder.FillQueue(numberOfTurnsToQueueFor);
        ChangeCombatStateOfThoseInCombat(true);
        SpiltCharactersInCombatIntoPlayerAndEnemy();

      //  GameManager.Instance.UpdateGameState(GameState.CombatDecider);
    }
    public void SetTurnsInRound()
    {
        turnsInAround = combatHolder.GetSortedTurnOrderList().Count;
    }

    public void ProcessTurn()
    {
        if (isCurrentCharacterTurnAPlayer())
        {
      //      GameManager.Instance.UpdateGameState(GameState.PlayerTurn);

        }
        else
        {
    //        GameManager.Instance.UpdateGameState(GameState.EnemyTurn);

        }
    }
    public void SetCurrentCharacterTurn()
    {
       // currentCharacterTurn = combatHolder.DequeueTurnOrder();
    }

    public GameObject GetCurrentCharacterTurn()
    {
        return currentCharacterTurn;
    }

    public void ChangeCombatStateOfThoseInCombat(bool state)
    {
        foreach (var item in combatHolder.charactersInCombat)
        {
        //    item.GetComponent<PlayerCombat>().inCombat = state;
        }
    }

    public void SpiltCharactersInCombatIntoPlayerAndEnemy()
    {
        foreach (var item in combatHolder.charactersInCombat)
        {
            if (IsCharacterAPlayer(item))
            {
                combatHolder.playerCharactersInCombat.Add(item);
            }
            else
            {
                combatHolder.enemyCharactersInCombat.Add(item);

            }
        }

    }




    public Queue<GameObject> GetTurnOrderQueue()
    {
        return combatHolder.GetTurnOrderQueue();
    }


    public bool DeathCheckPlayers()
    {
        int charactersDead = 0;
        foreach (var item in combatHolder.playerCharactersInCombat)
        {
            if (item.GetComponent<PlayerClass>().GetCurrentHP() <= 0)
            {
                charactersDead++;
            }
            else
            {
                return false;
            }

        }
        return true;
    }
    public bool DeathCheckEnemies()
    {
        int charactersDead = 0;
        foreach (var item in combatHolder.enemyCharactersInCombat)
        {
            if (item.GetComponent<PlayerClass>().GetCurrentHP() <= 0)
            {
                charactersDead++;
            }
            else
            {
                return false;
            }

        }

        return true;
    }
    public int GetRound()
    {
        return round;
    }
    public void IncreaseRound()
    {
        round = round + 1;
    }
    public bool CheckIfNewRound()
    {
        Debug.Log(turnsInAround);
        return (turnCounter >= turnsInAround);
         
            
    }
    public void IncreaseTurnCounter(){
        turnCounter = turnCounter+1;
    }

    public void ResetTurnCounter(){
        turnCounter = 0;
    }
      public void ResetRoundCounter(){
        round = 1;
    }


}
    
