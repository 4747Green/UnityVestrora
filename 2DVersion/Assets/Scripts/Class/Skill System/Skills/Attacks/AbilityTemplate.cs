using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Collections;

using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Abilities")]
public class AbilityTemplate : ScriptableObject, IComparer<AbilityTemplate>
{

    public string skillName = "BANG";
    public int toHit;
    public int reach;

    public string shape;
    public int targets;
    public int save;
    [Header("DamageRolls")]
    public Damage onFail;
    public Damage onSuccessful;
    public int recharge;
    System.Random rnd = new System.Random();


    public int Attack()
    {
        bool saveCheckPassed = true;
          int totalAttackDmg = 0;
        if (saveCheckPassed)
        {
            totalAttackDmg += rollDamage(onFail);
        }

        return totalAttackDmg;
    }



    public void AbilityTemplateConstructorSave(string skillName, int reach, string shape, int targets, Damage onFail)
    {
        this.skillName = skillName;
        this.reach = reach;
        this.shape = shape;
        this.targets = targets;
        this.onFail = onFail;


    }


    public void AbilityTemplateConstructo(string skillName, int toHit, int reach, int targets, Damage[] damageRolls)
    {
        this.skillName = skillName;
        this.toHit = toHit;
        this.reach = reach;
        this.targets = targets;
      
    }

    public int rollDamage(Damage damageRoll)
    {
        int total = 0;
        for (int i = 0; i < damageRoll.amountOfRolls; i++)
        {
            total += (rnd.Next(1, damageRoll.die) + damageRoll.mod);

        }
        return total;

    }
    public int Compare(AbilityTemplate x, AbilityTemplate y)
    {
        // TODO: Handle x or y being null, or them not having names
        return x.skillName.CompareTo(y.skillName);
    }


}


