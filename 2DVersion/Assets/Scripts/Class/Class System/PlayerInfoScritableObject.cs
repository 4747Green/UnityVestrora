using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu]
public class PlayerInfoScritableObject : ScriptableObject
{
    public AbilityHolder holder;
    public Arsenal Arsenal;
    public SavingThrows SavingThrows;
    public HitPoints HitPoints;
    public FightingStyle FightingStyle;
    public Archetype Archetype;
    public List<LevelTable> LevelTable;
    public int[] statArray = { 0, 0, 0, 0, 0, 0 };
    public int[] SkillOptionsByID = { 0, 0, 0, 0, 0, 0 };
    public int[] Tools;

    [SerializeField]
    public Stats playerStats;
    public PlayerInfoScritableObject()
    {



    }



}







