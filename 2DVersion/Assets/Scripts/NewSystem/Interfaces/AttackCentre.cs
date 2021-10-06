using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface AttackCentre
{


    void AddAttackToListOfAttacks(AttackTemp attack);
     int Attack(int attackID);
    void DoesAttackHit();
    void AttackDamage();

}