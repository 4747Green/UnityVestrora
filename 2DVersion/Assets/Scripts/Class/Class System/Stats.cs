using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using System.Linq;
[System.Serializable]
[CreateAssetMenu]
public class Stats
{

    public List<DndSkills> dndSkills = new List<DndSkills>(new DndSkills[]{
                         new DndSkills("Acrobatics",  2),
         new DndSkills("AnimalHandling", 2),
         new DndSkills("Arcana", 2),
         new DndSkills("Athletics", 2),

         new DndSkills("Deception", 2),
         new DndSkills("History", 2),
         new DndSkills("Insight", 2),
         new DndSkills("Intimidation", 2),
         new DndSkills("Investigation", 2),

         new DndSkills("Medicine", 2),
         new DndSkills("Nature", 2),
         new DndSkills("Perception", 2),
         new DndSkills("Performance", 2),
         new DndSkills("Persuasion", 2),

         new DndSkills("Religion", 2),
         new DndSkills("SleightOfHand", 2),
         new DndSkills("Stealth", 2),
         new DndSkills("Survival", 2)


        }
    );

    public List<SavingThrows> savingThrows = new List<SavingThrows>(new SavingThrows[]{
                         new SavingThrows("Strength",  2),
         new SavingThrows("Dexterity", 2),
         new SavingThrows("Constitution", 2),
         new SavingThrows("Intelligence", 2),

         new SavingThrows("Wisdom", 2),
         new SavingThrows("Charisma", 2),




        }
);

    public List<PrimaryStats> primaryStats = new List<PrimaryStats>(new PrimaryStats[]{
                         new PrimaryStats("Strength",  2,10),
         new PrimaryStats("Dexterity", 2,10),
         new PrimaryStats("Constitution", 2,10),
         new PrimaryStats("Intelligence", 2,10),

         new PrimaryStats("Wisdom", 2,10),
         new PrimaryStats("Charisma", 2,10),




        }
);
    public List<GeneralStats> generalStats = new List<GeneralStats>(new GeneralStats[]{
                         new GeneralStats("Level",  1),
         new GeneralStats("Speed", 15),
         new GeneralStats("Inspiration", 1),
         new GeneralStats("AC", 10),

         new GeneralStats("Intiative", 2),
         new GeneralStats("Proficiency", 2),




        }
);




    public Stats()
    {



    }
    public void Update()
    {

    }



    void GeneratePrimaryAbilityScoresAndModsAndSavingThrows(int[] statArray)
    {


        for (int i = 0; i < primaryStats.Count(); i++)
        {


            primaryStats[i].mod = Convert.ToInt32(Math.Floor((primaryStats[i].value - 10) / 2f));
            if (primaryStats[i].mod < 0)
            {
                primaryStats[i].mod = 0;
            }

            savingThrows[i].mod = primaryStats[i].mod;

        }


    }

    void GenerateAndUpdateProficiencyBonus()
    {


    }





    [System.Serializable]
    public class DndSkills
    {

        public int mod;
        public string name;


        public DndSkills(string name, int mod)
        {

            this.mod = mod;
            this.name = name;

        }
    }
    [System.Serializable]
    public class PrimaryStats
    {

        public int mod;
        public int value;
        public string name;


        public PrimaryStats(string name, int mod, int value)
        {

            this.mod = mod;
            this.name = name;
            this.value = value;
        }
    }
    [System.Serializable]
    public class SavingThrows
    {

        public int mod;
        public string name;



        public SavingThrows(string name, int mod)
        {

            this.mod = mod;
            this.name = name;

        }
    }

    [System.Serializable]
    public class GeneralStats
    {

        public int value;
        public string name;



        public GeneralStats(string name, int value)
        {

            this.value = value;
            this.name = name;

        }
    }



}







