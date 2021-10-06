using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;


[CreateAssetMenu(fileName = "New Attack", menuName = "Attacks")]
public class MeleeWeaponAttack : AttackTemplate
{
    System.Random rnd = new System.Random();

    public MeleeWeaponAttack()
    {
        

    }
 
}