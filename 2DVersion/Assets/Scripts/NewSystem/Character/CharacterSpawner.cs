using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
public class CharacterSpawner : MonoBehaviour
{
    static List<CharacterController> characterList = new List<CharacterController>();
    public GameObject prefab;
    public GameObject contentWindow;
     public static event Action<CharacterController> OnCharacterCreation;

      public static CharacterSpawner Instance;
    
       private void Awake()
    {
        Instance = this;
    }
   public void CreateCharacter(int  characterTypeIndex)
    {

        CharacterController character = ScriptableObject.CreateInstance<CharacterController>();
        character.SetUpCharacter(characterTypeIndex);
        character.text2 ="test";
     





        characterList.Add(character);
        GameObject newObj;
        newObj = (GameObject)Instantiate(prefab, contentWindow.transform, false);
        newObj.GetComponent<CharacterPlayerClass>().characterController = character;
        newObj.transform.parent = contentWindow.transform;
        OnCharacterCreation?.Invoke(newObj.GetComponent<CharacterPlayerClass>().characterController);

    }


}
