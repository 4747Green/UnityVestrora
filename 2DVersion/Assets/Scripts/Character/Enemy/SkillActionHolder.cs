using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public class SkillActionHolder 
{
    // Start is called before the first frame update

    public SkillTemplate skill;

    public List<SkillTemplate> skillList;
    public KeyCode keyBinding;
    public PlayerClass player;
    public int skillIndexLoaded;
    void Update()
    {   
        // if keybind is triggered and the list of skills is not empty or null, trigger the current loaded abilty 
        if ((Input.GetKeyDown(keyBinding) & (skillList != null || skillList.Count != 0)))
        {   
            skillList[skillIndexLoaded].Active(player);
        }


    }

    public SkillActionHolder()
    {

    }
    public void RefreshAllSkillChagres(){
        for(var i =0; i< skillList.Count; i++){
            skillList[i].refillCharges();


        }
    }

    public void SwitchCurrentLoadedAbility(SkillTemplate skillToFind)
    {
         skillIndexLoaded = skillList.FindIndex(item => item.skillName == skillToFind.skillName);        


    }
    // Update is called once per frame

}
