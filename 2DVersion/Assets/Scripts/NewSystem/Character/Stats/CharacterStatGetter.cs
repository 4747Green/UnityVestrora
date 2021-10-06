using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CharacterStatGetter
{

    public static int[] GetStats(CharacterEnums character)
    {
        int[] stats = new int[6];  //initializing array  


        switch (character)
        {
            case CharacterEnums.GiantSlime:
            stats = new int[]{15,10,18,3,6,3};
                break;
            case CharacterEnums.Nsia:
             stats = new int[]{15,18,18,17,11,12};
                break;
            case CharacterEnums.Mc:
             stats = new int[]{16,16,16,16,16,16};
                break;
            default:
                break;
        }
 
        return stats;

    }
    public static int[] GetAttack(CharacterEnums character)
    {
        int[] stats = new int[6];  //initializing array  


        switch (character)
        {
            case CharacterEnums.GiantSlime:
            stats = new int[]{15,10,18,3,6,3};
                break;
            case CharacterEnums.Nsia:
             stats = new int[]{15,18,18,17,11,12};
                break;
            case CharacterEnums.Mc:
             stats = new int[]{16,16,16,16,16,16};
                break;
            default:
                break;
        }
 
        return stats;

    }
}   
