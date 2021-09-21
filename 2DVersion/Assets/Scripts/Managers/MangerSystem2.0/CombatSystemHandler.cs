using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CombatSystemHandler : MyManagerBehavior
{

    private GameObject currentCharacterTurn;
    public CombatHolderForManager combatHolder;
    public int numberOfTurnsToQueueFor;
    
    public int GetNumberOfCharactersInCombat()
    {
        return combatHolder.charactersInCombat.Count;
    }

    public bool CheckIfCharacterIsDead(GameObject character)
    {
        Debug.Log("not implemented");
        return false;
    }
    public bool IsCurrentCharacterTurnSet()
    {
        if (currentCharacterTurn is null)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
    public bool IsThisCharacterAPlayer(GameObject character)
    {
        return character.GetComponent<PlayerCombat>().IsHeroPlayer();
    }
    public void RefillQueue(int turnsToRefillBy)
    {
       
            combatHolder.FillQueue(1);
        
    }

    public void InitializeAndFillSortedOrderListAndTurnOrderQueue()
    {
        combatHolder.FillSortedTurnOrderList();
        combatHolder.FillQueue(numberOfTurnsToQueueFor);
    }

    public int GetNumberOfTurnsToQueueFor()
    {
        return numberOfTurnsToQueueFor;
    }

    public void AddCharacterInCombatToPlayerOrEnemyList()
    {
        foreach (var item in combatHolder.charactersInCombat)
        {
            if (IsThisCharacterAPlayer(item))
            {
                combatHolder.playerCharactersInCombat.Add(item);
            }
            else
            {
                combatHolder.enemyCharactersInCombat.Add(item);

            }
        }
    }

    public void SetCurrentCharacterTurn()
    {
        currentCharacterTurn = combatHolder.DequeueTurnOrder();
    }

    public GameObject GetCurrentCharacterTurn()
    {
        return currentCharacterTurn;
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

    public void ClearData()
    {
        combatHolder.GetSortedTurnOrderList().Clear();
        combatHolder.GetTurnOrderQueue().Clear();
        currentCharacterTurn = null;

        combatHolder.enemyCharactersInCombat.Clear();
        combatHolder.playerCharactersInCombat.Clear();

    }



}

