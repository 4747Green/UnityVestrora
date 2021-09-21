using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CombatHolderForManager : MonoBehaviour
{



    public Queue<GameObject> turnOrderQueue = new Queue<GameObject>();
    public List<GameObject> charactersInCombat;
    public List<GameObject> enemyCharactersInCombat;
    public List<GameObject> playerCharactersInCombat;
    public SortedList<int, GameObject> sortedTurnOrderList = new SortedList<int, GameObject>();

 
    public Queue<GameObject> GetTurnOrderQueue()
    {
        return turnOrderQueue;
    }


    public GameObject DequeueTurnOrder()
    {
        if (turnOrderQueue.Count != 0)
        {
            return turnOrderQueue.Dequeue();
        }
        
        return charactersInCombat[0];


    }

    public SortedList<int, GameObject> GetSortedTurnOrderList()
    {
        return sortedTurnOrderList;
    }
    public void FillSortedTurnOrderList(){

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

  
}