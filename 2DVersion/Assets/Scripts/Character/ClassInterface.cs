using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ClassInterface 
{


    int GetLevel();
    int GetSpeed();
    int GetAC();
    int GetHP();
     Stats GetStats();
    int GetInitiative();
    int AttackRoll(bool isFinesse);
    int DamageRoll(bool isFinesse);
    int Check(bool advantage, bool disavantage, int mod, int toBeat, int die);
    


    // void levelUp();




}
