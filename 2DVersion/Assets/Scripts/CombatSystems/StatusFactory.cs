using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatusFactory
{

    // UI set to host 30 per token 22/09/2021
    public enum StatusType
    {
        Blinded,
        Charmed,
        Deafened,
        Frightened,
        Grappled,
        Incapacitated,
        Invisible,
        Paralyzed,
        Petrified,
        Poisoned,
        Prone,
        Restrained,
        Stunned,
        Surprised,
        Unconscious,
        Exhaustion
    }

    public static Status CreateStatus(StatusType statusType)
    {
        Status status;

        switch (statusType)
        {
            case StatusType.Blinded:
                status = new Status(1,2,statusType);
             //   status.AddStatusType(Status.StatusEffect.Biting, 5);
           //     status.AddStatusType(Status.StatusEffect.Kicking, 5);
                break;
            case StatusType.Charmed:
                status = new Status(1,2,statusType);
                status.AddStatusType(Status.StatusEffect.Biting, 5);
                status.AddStatusType(Status.StatusEffect.Kicking, 5);
                status.AddStatusType(Status.StatusEffect.Punching, 5);
                break;
            case StatusType.Deafened:
                status = new Status(1,2,statusType);
                status.AddStatusType(Status.StatusEffect.Biting, 5);
                break;
            case StatusType.Grappled:
                status = new Status(1,2,statusType);
                status.AddStatusType(Status.StatusEffect.Biting, 5);
                status.AddStatusType(Status.StatusEffect.Punching, 5);
                break;
            case StatusType.Incapacitated:
                status = new Status(1,2,statusType);
                status.AddStatusType(Status.StatusEffect.Kicking, 5);
                break;
            case StatusType.Invisible:
                status = new Status(1,2,statusType);
                status.AddStatusType(Status.StatusEffect.Kicking, 5);
                status.AddStatusType(Status.StatusEffect.Punching, 5);
                break;
            case StatusType.Paralyzed:
                status = new Status(1,2,statusType);
                status.AddStatusType(Status.StatusEffect.Punching, 5);
                break;
            case StatusType.Petrified:
                status = new Status(1,2,statusType);
                status.AddStatusType(Status.StatusEffect.Punching, 5);
                break;
            case StatusType.Poisoned:
                status = new Status(1,2,statusType);
                status.AddStatusType(Status.StatusEffect.Punching, 5);
                break;
            case StatusType.Prone:
                status = new Status(1,2,statusType);
                status.AddStatusType(Status.StatusEffect.Punching, 5);
                break;
            case StatusType.Restrained:
                status = new Status(1,2,statusType);
                status.AddStatusType(Status.StatusEffect.Punching, 5);
                break;
            case StatusType.Surprised:
                status = new Status(1,2,statusType);
                status.AddStatusType(Status.StatusEffect.Punching, 5);
                break;
            case StatusType.Unconscious:
                status = new Status(1,2,statusType);
                status.AddStatusType(Status.StatusEffect.Punching, 5);
                break;
            case StatusType.Exhaustion:
                status = new Status(1,2,statusType);
                status.AddStatusType(Status.StatusEffect.Punching, 5);
                break;
            default:
                throw new ArgumentException();
        }

        return status;
    }
}