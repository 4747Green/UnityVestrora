using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public class AttackTemp  
{
    public int id;
    public string name;
    public AttackTemp(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public int Attack(){
        Debug.Log("attack roll");
        return 14;
    }

}
