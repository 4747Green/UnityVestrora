using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Skills
{
    public int id;
    public Sprite icon;

    public string description;
    public string skillName;
    public int mod;
    public delegate int checkDelegate();

    public Func<int> funDel;
    public checkDelegate checkDelegateVarible;

    public bool isProficiencient = false;


    public Skills skill;

    public Skills(int _id, Sprite _icon, string _description, string _skillName, int _mod, Func<int> function)
    {

        skill = this;

        this.id = _id;
        this.icon = _icon;

        this.description = _description;
        this.skillName = _skillName;
        this.mod = _mod;
        this.funDel = function;
    

    }

}