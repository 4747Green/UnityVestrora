using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Status
{
    public enum StatusEffect
    {
        Biting,
        Kicking,
        Punching
    }
     public StatusFactory.StatusType statusType;

    public int roundDuration { get; set; }
    public int stack { get; set; }

    public Status(int roundDuration, int stack, StatusFactory.StatusType statusType)
    {
        this.statusType = statusType;
        this.stack = stack;
        this.roundDuration = roundDuration;

    }


    public Dictionary<StatusEffect, int> StatusEffects { get; set; }




    // These replace the functionality of checking an object's "type",
    // to see if it "is" a certain datatype (KickingMonster, BitingMonster, etc.)
    public bool CanBite => StatusEffects.ContainsKey(StatusEffect.Biting);
    public bool CanKick => StatusEffects.ContainsKey(StatusEffect.Kicking);
    public bool CanPunch => StatusEffects.ContainsKey(StatusEffect.Punching);

    public int BiteDamage
    {
        get
        {
            if (CanBite)
            {
                return StatusEffects[StatusEffect.Biting];
            }

            throw new NotSupportedException("This monster cannot bite.");
        }
    }

    public int KickDamage
    {
        get
        {
            if (CanKick)
            {
                return StatusEffects[StatusEffect.Kicking];
            }

            throw new NotSupportedException("This monster cannot kick.");
        }
    }

    public int PunchDamage
    {
        get
        {
            if (CanPunch)
            {
                return StatusEffects[StatusEffect.Punching];
            }

            throw new NotSupportedException("This monster cannot punch.");
        }
    }
    public void AddStatusType(StatusEffect statusEffect, int effectDuration)
        {
            StatusEffects[statusEffect] = effectDuration;
        }

}



