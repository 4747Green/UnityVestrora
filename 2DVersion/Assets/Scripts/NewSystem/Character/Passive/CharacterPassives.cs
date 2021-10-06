using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;



public class CharacterPassives 
{
    private List<PassiveTemp> passiveList;

    public CharacterPassives(List<PassiveTemp> passiveList)
    {
        this.passiveList = passiveList;
    }

    public void AddAttackToListOfPassives(PassiveTemp passive)
    {
        passiveList.Add(passive);
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
