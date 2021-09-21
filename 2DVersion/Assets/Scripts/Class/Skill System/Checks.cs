using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checks 
{


    // add mods
    public Stats statClass;
    public Sprite icon;
    public PlayerClass player;

     int[] statArray;
     int[] skillChoices;

    public delegate int checkDelegate();
    public checkDelegate checkDelegateVarible;



    public List<Skills> listOfSkills;
   

    public Checks(PlayerClass _player)
    {
   
              //  statClass = new Stats(statArray, skillChoices);

        listOfSkills  = new List<Skills>{
                new Skills(0, icon, "", "Strength Check", 1, StrengthCheck),
        new Skills(1, icon, "", "Dexterity Check", 1, StrengthCheck),
        new Skills(2, icon, "", "Constitution Check", 1, StrengthCheck),
        new Skills(3, icon, "", "Intelligence Check", 1, StrengthCheck),
        new Skills(4, icon, "", "Wisdom Check", 1, StrengthCheck),
        new Skills(5, icon, "", "Charisma Check", 1, StrengthCheck),

        new Skills(6, icon, "", "Strength Saving Throw Check", 1, StrengthCheck),
        new Skills(7, icon, "", "Dexterity Saving Throw Check", 1, StrengthCheck),
        new Skills(8, icon, "", "Constitution Saving Throw Check", 1, StrengthCheck),
        new Skills(9, icon, "", "Intelligence Saving Throw Check", 1, StrengthCheck),
        new Skills(10, icon, "", "WisdomSaving Throw Check", 1, StrengthCheck),
        new Skills(11, icon, "", "CharismaSaving Throw Check", 1, StrengthCheck),

        new Skills(12, icon, "", "AcrobaticsCheck", 1, StrengthCheck),
        new Skills(13, icon, "", "AnimalHandlingCheck", 1, StrengthCheck),
        new Skills(14, icon, "", "ArcanaCheck", 1, StrengthCheck),
        new Skills(15, icon, "", "AthleticsCheck", 1, StrengthCheck),
        new Skills(16, icon, "", "DeceptionCheck", 1, StrengthCheck),
        new Skills(17, icon, "", "HistoryCheck", 1, StrengthCheck),

        new Skills(18, icon, "", "InsightCheck", 1, StrengthCheck),
        new Skills(19, icon, "", "IntimidationCheck", 1, StrengthCheck),
        new Skills(20, icon, "", "InvestigationCheck", 1, StrengthCheck),
        new Skills(21, icon, "", "MedicineCheck", 1, StrengthCheck),
        new Skills(22, icon, "", "NatureCheck", 1, StrengthCheck),
        new Skills(23, icon, "", "PerceptionCheck", 1, StrengthCheck),

        new Skills(24, icon, "", "PerformanceCheck", 1, StrengthCheck),
        new Skills(25, icon, "", "PersuasionCheck", 1, StrengthCheck),
        new Skills(26, icon, "", "ReligionCheck", 1, StrengthCheck),
        new Skills(27, icon, "", "SleightOfHandCheck", 1, StrengthCheck),
        new Skills(28, icon, "", "StealthCheck", 1, StrengthCheck),
        new Skills(29, icon, "", "SurvivalCheck", 1, StrengthCheck)

    };
        //checkDelegateVarible = listOfSkills[1].checkDelegateVarible;






    }
    public int StrengthCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.primaryStats[0].mod, 0, 20);
                                     

        return roll;
    }
    public int DexterityCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.primaryStats[1].mod, 0, 20);
      

        return roll;
    }
    public int ConstitutionCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.primaryStats[2].mod, 0, 20);
        

        return roll;
    }
    public int IntelligenceCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.primaryStats[3].mod, 0, 20);

        return roll;
    }
    public int WisdomCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.primaryStats[4].mod, 0, 20);

        return roll;
    }
    public int CharismaCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.primaryStats[5].mod, 0, 20);

        return roll;
    }

    public int StrengthSavingThrowCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.savingThrows[0].mod, 0, 20);

        return roll;
    }
    public int DexteritySavingThrowCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.savingThrows[1].mod, 0, 20);

        return roll;
    }
    public int ConstitutionSavingThrowCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.savingThrows[2].mod, 0, 20);

        return roll;
    }
    public int IntelligenceSavingThrowCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.savingThrows[3].mod, 0, 20);

        return roll;
    }
    public int WisdomSavingThrowCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.savingThrows[4].mod, 0, 20);

        return roll;
    }
    public int CharismaSavingThrowCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.savingThrows[5].mod, 0, 20);

        return roll;
    }



    public int AcrobaticsCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[0].mod, 0, 20);

        return roll;
    }
    public int AnimalHandlingCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[1].mod, 0, 20);

        return roll;
    }
    public int ArcanaCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[2].mod, 0, 20);

        return roll;
    }
    public int AthleticsCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[3].mod, 0, 20);

        return roll;
    }
    public int DeceptionCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[4].mod, 0, 20);

        return roll;
    }
    public int HistoryCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[5].mod, 0, 20);

        return roll;
    }
    public int InsightCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[6].mod, 0, 20);
        return roll;
    }
    public int IntimidationCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[7].mod, 0, 20);
        return roll;
    }
    public int InvestigationCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[8].mod, 0, 20);
        return roll;
    }

    public int MedicineCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[9].mod, 0, 20);
        return roll;
    }
    public int NatureCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[10].mod, 0, 20);
        return roll;
    }
    public int PerceptionCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[11].mod, 0, 20);
        return roll;
    }
    public int PerformanceCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[12].mod, 0, 20);
        return roll;
    }
    public int PersuasionCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[13].mod, 0, 20);
        return roll;
    }
    public int ReligionCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[14].mod, 0, 20);
        return roll;
    }
    public int SleightOfHandCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[15].mod, 0, 20);
        return roll;
    }
    public int StealthCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[16].mod, 0, 20);
        return roll;
    }
    public int SurvivalCheck()
    {
        int roll = check(false, false, player.playerChosenClass.playerStats.playerStats.dndSkills[17].mod, 0, 20);
        return roll;
    }


    public int invoke(int id)
    {
       return listOfSkills[0].funDel();

    }






    public int check(bool advantage, bool disavantage, int mod, int toBeat, int die)
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
