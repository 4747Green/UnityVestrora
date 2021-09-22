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
    
    public List<GameObject> charactersWhoDied;
    [System.NonSerialized]
    public int round = 1;

    [System.NonSerialized]
    public int turn = 1;

    public void TurnIncrease()
    {

        turn++; 
        if (turn > charactersInCombat.Count)
        {
            turn = 1;
            round++;
            RefillQueue();
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
        public List<GameObject> GetCharactersInCombat()
    {
        return charactersInCombat;
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
    public void RefillQueue()
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

    public void RemoveFromCombat(GameObject character)
    {

        charactersInCombat.Remove(character);
        enemyCharactersInCombat.Remove(character);
        playerCharactersInCombat.Remove(character);

        int index =sortedTurnOrderList.IndexOfValue(character);
       
        sortedTurnOrderList.RemoveAt(index);


        turnOrderQueue.Clear();
        FillQueue(numberOfTurnsToQueueFor);
        charactersWhoDied.Add(character);

    }

    public static bool IsEmpty<T>(List<T> list)
    {
        if (list == null)
        {
            return true;
        }

        return !list.Any();
    }






    public bool DeathCheckPlayers()
    {

        bool isEmpty = IsEmpty(playerCharactersInCombat);

        if (isEmpty)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DeathCheckEnemies()
    {
        bool isEmpty = IsEmpty(enemyCharactersInCombat);
        if (isEmpty)
        {
            return true;
        }
        else
        {
            return false;
        }


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
