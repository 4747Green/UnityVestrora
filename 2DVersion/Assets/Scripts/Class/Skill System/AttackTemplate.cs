using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "New Attack", menuName = "Attacks")]
public class AttackTemplate : ScriptableObject, IComparer<AttackTemplate>
{

    public string skillName ="BANG";
    public int toHit;
    public int reach;
    public int targets;
    [Header("DamageRolls")]

    public Damage[] DamageRolls;
    System.Random rnd = new System.Random();


    public  int Attack()
    {
        int totalAttackDmg=0;
        foreach (var item in DamageRolls)
        {
            totalAttackDmg += rollDamage(item);
        }
        return totalAttackDmg;
    }



    public void AttackTemplateConstructor(string skillName, int toHit, int reach, int targets, Damage[] damageRolls)
    {
        this.skillName = skillName;
        this.toHit = toHit;
        this.reach = reach;
        this.targets = targets;
        DamageRolls = damageRolls;
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
    public int Compare(AttackTemplate x, AttackTemplate y)
    {
        // TODO: Handle x or y being null, or them not having names
        return x.skillName.CompareTo(y.skillName);
    }


}


