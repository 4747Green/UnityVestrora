using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SkillTemplate : ScriptableObject,IComparer<SkillTemplate> {
    
    public string skillName;
    public int charges;
    public int maxCharges;
    public virtual int Active(PlayerClass player){

        return 0;
    }


       public void decreaseCharges()
    {
        charges = charges - 1;
        if (charges < 0)
        {
            charges = 0;
        }
    }

    public void Awake(){
        charges = maxCharges;
    }
    public void increaseCharges()
    {
        charges = charges + 1;
        if (charges > maxCharges)
        {
            charges = maxCharges;
        }
    }

    public void refillCharges()
    {
        charges = maxCharges;
    }

    public void increaseMaxCharges()
    {
        maxCharges = maxCharges + 1;
    }



    // Checks if Given spell has charges and retruns TRUE if it does.
    public bool HasCharges()
    {


        return this.charges > 0;


    }
    public int Compare(SkillTemplate x, SkillTemplate y)
    {
        // TODO: Handle x or y being null, or them not having names
        return x.skillName.CompareTo(y.skillName);
    }
}
