using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Collections;

using UnityEngine;


public class EnemyClassTemplate : MonoBehaviour, ClassInterface
{
    public PlayerInfoScritableObject playerStats;


    // public string[] classActionsList = { "SecondWind", "ActionSurge", "Indomitable" };



    public EnemyClassTemplate()
    {




    }


    public int AttackRoll(bool isFinesse)
    {

        int roll = Check(false, false, 0, 0, 20);


        if (this.IsProficient())
        {
            roll = roll + playerStats.playerStats.generalStats[5].value;
        }
        if (isFinesse)
        {
            roll = roll + playerStats.playerStats.primaryStats[1].mod;
        }
        else
        {
            roll = roll + playerStats.playerStats.primaryStats[0].mod;
        }

        return roll;

    }

    public int GetLevel()
    {
        return 2;
    }
    public int GetSpeed()
    {
        return 2;
    }
    public int GetAC()
    {
        return 2;
    }

    //this shit not right
    public int GetHP()
    {
        return 10;
    }
    public Stats GetStats()
    {
        return playerStats.playerStats;
    }
    public int DamageRoll(bool isFinesse)
    {
        // Class for handling weapons and their rolls
        int roll = 5;



        if (isFinesse)
        {
            roll = roll + playerStats.playerStats.primaryStats[1].mod;
        }
        else
        {
            roll = roll + playerStats.playerStats.primaryStats[0].mod;
        }

        return roll;


    }
    public bool IsProficient()
    {
        return true;
    }
    public int GetInitiative()
    {
        return this.playerStats.playerStats.generalStats[3].value;
    }

    public int Check(bool advantage, bool disavantage, int mod, int toBeat, int die)
    {


        if (advantage)
        {
            int temp1 = UnityEngine.Random.Range(1, die);
            int temp2 = UnityEngine.Random.Range(1, die);

            if (temp1 >= temp2)
            {
                return (temp1 + mod) - toBeat;
            }
            else
            {
                return (temp2 + mod) - toBeat;
            }

        }
        if (disavantage)
        {

            int temp1 = UnityEngine.Random.Range(1, die);
            int temp2 = UnityEngine.Random.Range(1, die);

            if (temp1 <= temp2)
            {
                return (temp1 + mod) - toBeat;
            }
            else
            {
                return (temp2 + mod) - toBeat;
            }
        }
        return (UnityEngine.Random.Range(1, die) + mod) - toBeat;
    }





























}

