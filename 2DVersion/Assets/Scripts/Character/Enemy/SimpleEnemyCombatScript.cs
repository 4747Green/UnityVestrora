using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SimpleEnemyCombatScript : MonoBehaviour
{

    public PlayerClass playerClass;

    public void CombatTurnAction()
    {

        StartCoroutine(ExampleCoroutine());


    }

    public void FindAndSetPlayerAsTarget()
    {
        this.playerClass.playerCombat.targetedEnemy = GameObject.FindGameObjectWithTag("Player");

    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started turn at timestamp : " + Time.time);
        this.playerClass.playerCombat.CallToTakeCombatAction(CombatActionsHandler.ActionTypeState.MeeleAttack);
        yield return new WaitForSeconds(1);

        this.playerClass.playerCombat.CallToTakeCombatAction(CombatActionsHandler.ActionTypeState.MeeleAttack);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        this.playerClass.playerCombat.CallToTakeCombatAction(CombatActionsHandler.ActionTypeState.MeeleAttack);
        yield return new WaitForSeconds(1);
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished turn at timestamp : " + Time.time);
    }
}