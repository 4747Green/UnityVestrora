using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ClassTemplate : MonoBehaviour, ClassInterface
{
    public AbilityHolder holder;
    public PlayerClass player;

    public PlayerInfoScritableObject playerStats;


    // public string[] classActionsList = { "SecondWind", "ActionSurge", "Indomitable" };



    public ClassTemplate()
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
    public int GetInitiative(){
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






[System.Serializable]
// add class prof to saving throw if prof is true
public class SavingThrows
{
    public bool StrengthSavingThrow;
    public bool DexteritySavingThrow;
    public bool ConstitutionSavingThrow;
    public bool IntelligenceSavingThrow;
    public bool WisdomSavingThrow;
    public bool CharismaSavingThrow;

    public SavingThrows(bool StrengthSavingThrow, bool DexteritySavingThrow, bool ConstitutionSavingThrow,
    bool IntelligenceSavingThrow, bool WisdomSavingThrow, bool CharismaSavingThrow)
    {
        this.StrengthSavingThrow = StrengthSavingThrow;
        this.DexteritySavingThrow = DexteritySavingThrow;
        this.ConstitutionSavingThrow = ConstitutionSavingThrow;
        this.IntelligenceSavingThrow = IntelligenceSavingThrow;
        this.WisdomSavingThrow = WisdomSavingThrow;
        this.CharismaSavingThrow = CharismaSavingThrow;
    }
}

[System.Serializable]
public class Arsenal
{
    public bool SimpleWeapons;
    public bool MartialWeapons;
    public bool Shield;
    public bool LightArmor;
    public bool MediumArmor;
    public bool HeavyArmor;

    public Arsenal(bool SimpleWeapons, bool MartialWeapons, bool Shield,
    bool LightArmor, bool MediumArmor, bool HeavyArmor)
    {
        this.SimpleWeapons = SimpleWeapons;
        this.MartialWeapons = MartialWeapons;
        this.Shield = Shield;
        this.LightArmor = LightArmor;
        this.MediumArmor = MediumArmor;
        this.HeavyArmor = HeavyArmor;
    }


}


[System.Serializable]
public class HitPoints
{
    public int HitDice;
    public int hitPointsAt1stLevel = 10;
    public int hitPointsAtHigherLevels;
    public int altHitPointsAtHigherLevels;

    public LevelUpMod LevelUpModifier;



    public HitPoints(int HitDice, int hitPointsAt1stLevel, int hitPointsAtHigherLevels,
    bool LightArmor, bool MediumArmor, bool HeavyArmor, LevelUpMod LevelUpModifier)
    {
        this.HitDice = HitDice;
        this.hitPointsAt1stLevel = hitPointsAt1stLevel;
        this.hitPointsAtHigherLevels = hitPointsAtHigherLevels;
        this.LevelUpModifier = LevelUpModifier;

    }


    [System.Serializable]
    public class LevelUpMod
    {
        public bool StrengthMod;
        public bool DexterityMod;
        public bool ConstitutionMod;
        public bool IntelligenceMod;
        public bool WisdomMod;
        public bool CharismaMod;

        public LevelUpMod(bool StrengthMod, bool DexterityMod, bool ConstitutionMod,
        bool IntelligenceMod, bool WisdomMod, bool CharismaMod)
        {
            this.StrengthMod = StrengthMod;
            this.DexterityMod = DexterityMod;
            this.ConstitutionMod = ConstitutionMod;
            this.IntelligenceMod = IntelligenceMod;
            this.WisdomMod = WisdomMod;
            this.CharismaMod = CharismaMod;
        }
    }
}
[System.Serializable]
public class FightingStyle
{
    public bool Archery;
    public bool Defense;
    public bool Dueling;
    public bool GreatWeaponFighting
;
    public bool Protection;

    public FightingStyle(bool Archery, bool Defense, bool Dueling,
    bool GreatWeaponFighting, bool Protection)
    {
        this.Archery = Archery;
        this.Defense = Defense;
        this.Dueling = Dueling;
        this.GreatWeaponFighting = GreatWeaponFighting;
        this.Protection = Protection;
    }


}

[System.Serializable]
public class Archetype
{
    public bool ElementalWarrior;
    public bool Branded;
    public bool Redeemer;
    public bool Champion;


    public Archetype(bool ElementalWarrior, bool Branded, bool Redeemer,
    bool Champion)
    {
        this.ElementalWarrior = ElementalWarrior;
        this.Branded = Branded;
        this.Redeemer = Redeemer;
        this.Champion = Champion;
    }


}




[System.Serializable]
public class LevelTable
{
    private string name;
    public int Level;
    public int ProficiencyBonus;
    public LevelBonusFeatures BonusFeatures;


    public LevelTable(LevelBonusFeatures BonusFeatures, int ProficiencyBonus, int Level)
    {

        this.BonusFeatures = BonusFeatures;
        this.ProficiencyBonus = ProficiencyBonus;
        this.Level = Level;
        setElementName();
    }

    private void setElementName()
    {
        this.name = name + " " + Level;
    }


    [System.Serializable]

    public class LevelBonusFeatures
    {
        public bool FightingStyle;
        public bool ClassPower;
        public bool Archetype;
        public bool AbilityScoreImprovement;

        public bool ExtraAttack;
        public bool ArchetypeFeature;



        public LevelBonusFeatures(bool FightingStyle, bool ClassPower, bool Archetype,
    bool AbilityScoreImprovement, bool ExtraAttack, bool ArchetypeFeature)
        {
            this.FightingStyle = FightingStyle;
            this.ClassPower = ClassPower;
            this.Archetype = Archetype;
            this.AbilityScoreImprovement = AbilityScoreImprovement;
            this.ExtraAttack = ExtraAttack;
            this.ArchetypeFeature = ArchetypeFeature;

        }
    }



}


[System.Serializable]

public class ClassDescription
{
    public string classGeneralDescription;
    public string hitPointsDescription;
    public string armorProficiencies;
    public string weaponProficiencies;

    public string toolProficiencies;
    public string savingThrowsProficiencies;
    public string equipmentDescription;
    public string fightingStyleDescription;
    public string subClassDescription;
    public string extraAttackDescription;

    public string abilityScoreImprovementDescription;

    public string futurePowersDescription;
    public string futureSpellsDescription;

    public ClassDescription(string classGeneralDescription, PlayerInfoScritableObject playerStats){



        this.classGeneralDescription = classGeneralDescription;


        this.hitPointsDescription = String.Format(
            "Staring Hit Points are {0} + your constitution modifier and " +
             "1d{1} or {2} + your constitution modifier for each level there after, " +
              "you also gain 1d{3} Hit Dice per level.",
            playerStats.HitPoints.hitPointsAt1stLevel,
            playerStats.HitPoints.hitPointsAtHigherLevels,
            playerStats.HitPoints.altHitPointsAtHigherLevels,
            playerStats.HitPoints.HitDice);


    }
}




