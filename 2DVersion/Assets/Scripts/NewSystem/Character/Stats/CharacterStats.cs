using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public class CharacterStats
{
    public int STR;
    public int DEX;
    public int CON;
    public int INT;
    public int WIS;
    public int CHA;

    public CharacterStats(int[] stats)
    {
        STR = stats[0];
        DEX = stats[1];
        CON = stats[2];
        INT = stats[3];
        WIS = stats[4];
        CHA = stats[5];
    }
}
