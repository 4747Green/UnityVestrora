using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class AttackFactory
{
    static List<AttackTemplate> attackList = new List<AttackTemplate>();
    static List<AbilityTemplate> abilityList = new List<AbilityTemplate>();

    public static AttackTemplate CreateAttack(string name, int toHit, int reach, int targets, Damage[] damageRolls)
    {
        var attack = ScriptableObject.CreateInstance<AttackTemplate>();
        attack.AttackTemplateConstructor(name, toHit, reach, targets, damageRolls);
        attackList.Add(attack);
        return attack;
    }

    public static AbilityTemplate CreateAbilitySave(string skillName, int reach, string shape, int targets,  Damage onSuccessful)
    {

        var ability = ScriptableObject.CreateInstance<AbilityTemplate>();
        ability.AbilityTemplateConstructorSave(skillName, reach, shape, targets, onSuccessful);
        abilityList.Add(ability);
        return ability;

    }

}

