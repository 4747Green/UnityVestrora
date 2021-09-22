using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SimpleEnemyCombatScript : MonoBehaviour
{

    public PlayerClass playerClass;
    private bool exampleCoroutineRunning;
    public void CombatTurnAction()
    {
        if (exampleCoroutineRunning)
        {

        }
        else
        {
            StartCoroutine(ExampleCoroutine());
        }



    }

    public void FindAndSetPlayerAsTarget()
    {
        this.playerClass.playerCombat.targetedEnemy = GameObject.FindGameObjectWithTag("Player");

    }
    IEnumerator ExampleCoroutine()
    {
        exampleCoroutineRunning = true;
        //Print the time of when the function is first called.

        while (playerClass.playerCombat.playerCombatHandler.GetTurnInProcess())
        {
            this.playerClass.playerCombat.CallToTakeCombatAction(CombatActionsHandler.ActionTypeState.MeeleAttack);
            yield return new WaitForSeconds(1);


        }


        exampleCoroutineRunning = false;
    }
}