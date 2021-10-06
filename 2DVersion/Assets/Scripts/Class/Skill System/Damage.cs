using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;


[System.Serializable]

public class Damage
{
    [SerializeField]
    public int amountOfRolls;
    public int die;
    public int mod;
    public String dmg;

    public Damage(int amountOfRolls, int die, int mod, string dmg)
    {
        this.amountOfRolls = amountOfRolls;
        this.die = die;
        this.mod = mod;
        this.dmg = dmg;
    }
}