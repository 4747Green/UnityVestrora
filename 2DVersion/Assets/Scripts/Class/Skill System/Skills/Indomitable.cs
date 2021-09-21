using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu]
public class Indomitable : SkillTemplate
{

    public Indomitable()
    {
        skillName = "Indomitable";
    }
    public override int Active(PlayerClass player)
    {

        Debug.Log("Indomitable");
        if (this.HasCharges())
        {
            this.decreaseCharges();



            Debug.Log("Indomitable!" + " effects not coded");




            return 1;


        }
        return 0;

    }
}