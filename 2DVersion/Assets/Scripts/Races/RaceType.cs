using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public class RaceType : EnumerationRace
{
    public static  RaceType Aberrations
        = new RaceType(0, "Aberrations");
    public static readonly RaceType Beasts
         = new RaceType(0, "Beasts");
    public static readonly RaceType Celestials
            = new RaceType(0, "Celestials");

    public static readonly RaceType Dragons
            = new RaceType(0, "Dragons");

    public static readonly RaceType Elementals
            = new RaceType(0, "Elementals");

    public static readonly RaceType Feys
            = new RaceType(0, "Feys");

    public static readonly RaceType Fiends
            = new RaceType(0, "Fiends");

    public static readonly RaceType Giants
            = new RaceType(0, "Giants");

    public static readonly RaceType Humanoids
            = new RaceType(0, "Humanoids");
    public static readonly RaceType Monstrosities
            = new RaceType(0, "Monstrosities");

    public static readonly RaceType Oozes
            = new RaceType(0, "Oozes");

    public static readonly RaceType Plants
            = new RaceType(0, "Plants");

    public static readonly RaceType Undead
            = new RaceType(0, "Undead");

    public static readonly RaceType Other
            = new RaceType(0, "Other");

    private RaceType() { }
    private RaceType(int value, string displayName) : base(value, displayName) { }
}
