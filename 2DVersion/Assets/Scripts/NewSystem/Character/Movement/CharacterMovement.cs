using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement
{
    public int speed = 25;
    public int climb = 25;

    public CharacterMovement(int speed, int climb)
    {
        this.speed = speed;
        this.climb = climb;
    }
}
