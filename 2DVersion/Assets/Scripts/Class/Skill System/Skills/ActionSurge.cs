using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu]
public class ActionSurge : SkillTemplate
{

    public ActionSurge()
    {
        skillName = "ActionSurge";
    }
    public override int Active(PlayerClass player)
    {

        Debug.Log("ActionSurge");
        if (this.HasCharges())
        {
            this.decreaseCharges();



            player.playerCombat.actionsEconomyThisTurn = player.playerCombat.actionsEconomyThisTurn + 1;

            Debug.Log("Action surge, you are granted an addiontal action");





            return 1;


        }
        return 0;

    }
}