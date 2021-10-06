using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;




[CreateAssetMenu(fileName = "CharacterController", menuName = "CharacterController")]
public class CharacterController : ScriptableObject
{
    public string tex = "hello";
    public string text2;
    public CharacterContainer characterContainer;
   

    void Update()
    {

    }

    public void SetUpCharacter(int characterTypeIndex){

        Debug.Log(characterTypeIndex+" con");
 

        characterContainer = new CharacterContainer(characterTypeIndex);

       
    }




}
