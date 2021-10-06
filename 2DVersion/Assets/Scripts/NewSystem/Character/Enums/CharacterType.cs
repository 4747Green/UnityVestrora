using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class CharacterType : EnumerationCharacter
{

    public static List<CharacterType> CharacterList = new List<CharacterType>{
        new CharacterType(0, "Nsia",
           new CharacterStats(new int[] { 15, 18, 18, 17, 11, 12 }),
           new CharacterHealth(64),
           new CharacterAttacks(new List<AttackTemp>(new AttackTemp[]{
            new AttackTemp(1,"Strike"),
            new AttackTemp(2, "Follow Through"),
            new AttackTemp(2, "Bless Of Selene"),
            new AttackTemp(2, "Crow"),
            new AttackTemp(2, "Mark Of Vireo"),
            new AttackTemp(2, "Predate"),
            new AttackTemp(2, "Moonful"),
            new AttackTemp(2, "Moonfall"),
                        new AttackTemp(2, "Crescent Fall"),
            new AttackTemp(3,"Moonlight"),
            new AttackTemp(3,"Raven's call"),
                new AttackTemp(3,"Gouge"),
                new AttackTemp(3,"An unkindness"),
                new AttackTemp(3,"Dive")


        })),
           new CharacterSpells(new List<SpellTemp>(new SpellTemp[]{
            new SpellTemp(1),
            new SpellTemp(2),
            new SpellTemp(3)

        })),
                new CharacterPassives(new List<PassiveTemp>(new PassiveTemp[]{
            new PassiveTemp(1,"test"),
            new PassiveTemp(2,"bang"),
            new PassiveTemp(3,"asha")

        })),



         new CharacterReactions(new List<ReactionTemp>(new ReactionTemp[]{
            new ReactionTemp(1,"test"),
            new ReactionTemp(2,"bang"),
            new ReactionTemp(3,"asha")

        })),
        new CharacterMovement(25, 25)

        )
    };


    private CharacterType() { }
    private CharacterType(int value, string displayName, CharacterStats characterStats, CharacterHealth characterHealth,
     CharacterAttacks characterAttacks, CharacterSpells characterSpells, CharacterPassives characterPassives,
     CharacterReactions characterReactions, CharacterMovement characterMovement)
     : base(value, displayName, characterStats, characterHealth, characterAttacks, characterSpells, characterPassives, characterReactions, characterMovement) { }

}