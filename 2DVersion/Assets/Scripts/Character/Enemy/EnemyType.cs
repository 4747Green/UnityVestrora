using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class EnemyType : EnumerationEnemy
{
    public static List<EnemyType> EnemyTypes = new List<EnemyType>{
       
        new EnemyType(1, "Slime",RaceType.Giants,  new List<AttackTemplate>(new AttackTemplate[]{

            AttackFactory.CreateAttack("Pseudopod",5,5,1,new Damage[] { new Damage(1,8,2,"Bludgeoning"), new Damage(3,6,0,"Acid")})

        }),
        new List<AbilityTemplate>(new AbilityTemplate[]{

            AttackFactory.CreateAbilitySave("Acid Spray",3,"cone",6,new Damage(5,8,0,"Acid"))
        }))
    };




    public EnemyType() { }

    public static string AddToEnemyType(EnemyInfoTest enemyInfo){
        
        
        return new RandomType(enemyInfo).ID;
    }



    private EnemyType(int value, string displayName, RaceType raceType, List<AttackTemplate> attackList,List<AbilityTemplate> ablityList) : base(value, displayName, raceType,attackList,ablityList)
    {
        if (EnemyTypes != null) { EnemyTypes.Add(this); }
    }

    public virtual int Speed { get => 30; }
    public String Test()
    {
        return "bang";
    }






    private class RandomType : EnemyType
    {

        public RandomType(EnemyInfoTest enemyInfo)
        {
            this.EnemyInfoTest = enemyInfo;
            this.DisplayName = "random";
            this.RaceType =  RaceType.Fiends;
            this.Value = 10;









            if (EnemyTypes != null) { EnemyTypes.Add(this); }
        }

        public override int Speed
        {
            get { return 50; }
        }
    }

}
