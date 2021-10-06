using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class CharacterContainer
{
    public string tex = "basa";

    public CharacterStats characterStats;
    public CharacterHealth characterHealth;

    public CharacterAttacks characterAttacks;
    public CharacterSpells characterSpells;
    public CharacterPassives characterPassives;
    public CharacterReactions characterReactions;
    public CharacterMovement characterMovement;

    public CharacterContainer(int characterTypeIndex)
    {      
        CharacterType bang = CharacterType.CharacterList[characterTypeIndex];
        Debug.Log(bang.DisplayName +" bangs");
        Debug.Log(CharacterType.CharacterList[characterTypeIndex].DisplayName);
        this.characterStats =  CharacterType.CharacterList[characterTypeIndex].Stats;
        this.characterHealth =  CharacterType.CharacterList[characterTypeIndex].Health;
        this.characterAttacks =  CharacterType.CharacterList[characterTypeIndex].Attacks;
        this.characterSpells =  CharacterType.CharacterList[characterTypeIndex].Spells;
        this.characterPassives =  CharacterType.CharacterList[characterTypeIndex].Passives;
        this.characterReactions =  CharacterType.CharacterList[characterTypeIndex].Reactions;
        this.characterMovement =  CharacterType.CharacterList[characterTypeIndex].Movement;
    }
}
