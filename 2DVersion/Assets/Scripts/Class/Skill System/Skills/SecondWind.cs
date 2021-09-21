using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu]
public class SecondWind : SkillTemplate {
    
            public SecondWind(){
        skillName = "SecondWind";
    }
    public override int Active(PlayerClass player){
        
        Debug.Log("test");
        if (this.HasCharges())
        {
            this.decreaseCharges();
            int healAmount = UnityEngine.Random.Range(1, 10) + player.playerChosenClass.playerStats.playerStats.generalStats[0].value;
            player.Heal(healAmount);
            Debug.Log("heals for" + healAmount);
            return healAmount;
        }
        return 0;

    }
}