using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;



public class CharacterReactions 
{
    private List<ReactionTemp> reactionList;

    public CharacterReactions(List<ReactionTemp> reactionList)
    {
        this.reactionList = reactionList;
    }

    public void AddAttackToListOfAttacks(ReactionTemp reaction)
    {
        reactionList.Add(reaction);
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



