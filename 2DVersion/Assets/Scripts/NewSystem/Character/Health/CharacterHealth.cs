using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public class CharacterHealth
{

    public int currentHealth;
    public int maxHealth;

    public CharacterHealth(int maxHealth)
    {
        this.currentHealth = maxHealth;
        this.maxHealth = maxHealth;
    }

    public void TakeDamage()
    {
        throw new NotImplementedException();
    }
    public void Heal()
    {
        throw new NotImplementedException();
    }

}
