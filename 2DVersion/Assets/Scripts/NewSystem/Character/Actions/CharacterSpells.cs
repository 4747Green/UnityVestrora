using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CharacterSpells 
{
    private List<SpellTemp> characterSpells;

    public CharacterSpells(List<SpellTemp> characterSpells)
    {
        this.characterSpells = characterSpells;
    }

    public void AddAttackToListOfSpellAttacks(SpellTemp spell)
    {
        characterSpells.Add(spell);
    }

    public int Attack(int attackID)
    {
        int index = characterSpells.FindIndex(x => x.id == (attackID));
       return characterSpells[index].Attack();

    }

    public void AttackDamage()
    {
        throw new NotImplementedException();
    }

    public void DoesAttackHit()
    {
        throw new NotImplementedException();
    }
}

