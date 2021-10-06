using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;



public class CharacterAttacks :  AttackCentre
{
    private List<AttackTemp> attackList;

    public CharacterAttacks(List<AttackTemp> attackList)
    {
        this.attackList = attackList;
    }
    public List<AttackTemp> GetAttackList(){
        return attackList;
    }

    public void AddAttackToListOfAttacks(AttackTemp attack)
    {
        attackList.Add(attack);
    }

    public int Attack(int attackID)
    {
        int index = attackList.FindIndex(x => x.id == (attackID));
       return attackList[index].Attack();

    }

    public void AttackDamage()
    {
        throw new NotImplementedException();
    }

    public void DoesAttackHit()
    {
        throw new NotImplementedException();
    }
 
}



