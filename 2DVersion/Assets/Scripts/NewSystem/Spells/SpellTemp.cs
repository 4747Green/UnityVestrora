using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public class SpellTemp  
{
    public int id;

    public SpellTemp(int id)
    {
        this.id = id;
    }

    public int Attack(){
        Debug.Log("Spell attack roll");
        return 14;
    }

}
