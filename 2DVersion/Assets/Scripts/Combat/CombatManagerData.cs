using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
    public class CombatManagerData : MyManagerBehavior
{

    private GameObject currentCharacterTurn;
    public int numberOfTurnsToQueueFor;
    public Queue<GameObject> turnOrderQueue = new Queue<GameObject>();
    public List<GameObject> charactersInCombat;
    public List<GameObject> enemyCharactersInCombat;
    public List<GameObject> playerCharactersInCombat;
    public SortedList<int, GameObject> sortedTurnOrderList = new SortedList<int, GameObject>();

    [System.NonSerialized]
    public int round =1;
    
    [System.NonSerialized]
    public int turn =1;

    public void TurnIncrease(){

        turn++;
        if(turn >= charactersInCombat.Count){
            turn = 1;
            round++;
        }
    }
    public int GetNumberOfCharactersInCombat()
    {
        return charactersInCombat.Count;
    }
    public Queue<GameObject> GetTurnOrderQueue()
    {
        return turnOrderQueue;
    }

    public bool IsThisCharacterAPlayer(GameObject character)
    {
        return character.GetComponent<PlayerCombat>().IsHeroPlayer();
    }
    public void DequeueTurnOrder()
    {
     
        
        currentCharacterTurn = turnOrderQueue.Dequeue();
         


    }
    public void InitializeAndFillSortedOrderListAndTurnOrderQueue()
    {
        FillSortedTurnOrderList();
        FillQueue(numberOfTurnsToQueueFor);
    }
    public void RefillQueue(int turnsToRefillBy)
    {

        FillQueue(1);

    }
    public SortedList<int, GameObject> GetSortedTurnOrderList()
    {
        return sortedTurnOrderList;
    }
    public void FillSortedTurnOrderList()
    {

        foreach (var item in charactersInCombat)
        {
            int initiative = item.GetComponent<PlayerClass>().playerClassController.GetInitiative();
            int initiativeRoll = item.GetComponent<PlayerClass>().playerClassController.Check(false, false, initiative, 0, 20);

            sortedTurnOrderList.Add(initiativeRoll, item);
        }
    }



    public void FillQueue(int numberOfRoundsToQueueFor)
    {
        for (int i = 0; i < numberOfRoundsToQueueFor; i++)
        {
            foreach (var item in sortedTurnOrderList)
            {
                turnOrderQueue.Enqueue(item.Value);
            }

        }
    }
    public void AddCharacterInCombatToPlayerOrEnemyList()
    {
        foreach (var item in charactersInCombat)
        {
            if (IsThisCharacterAPlayer(item))
            {
                playerCharactersInCombat.Add(item);
            }
            else
            {
                enemyCharactersInCombat.Add(item);

            }
        }
    }


    public GameObject GetCurrentCharacterTurn()
    {
        return currentCharacterTurn;
    }








    public bool DeathCheckPlayers()
    {
        int charactersDead = 0;
        foreach (var item in playerCharactersInCombat)
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
        foreach (var item in enemyCharactersInCombat)
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
        GetSortedTurnOrderList().Clear();
        turnOrderQueue.Clear();
        currentCharacterTurn = null;

        enemyCharactersInCombat.Clear();
        playerCharactersInCombat.Clear();

    }


}
