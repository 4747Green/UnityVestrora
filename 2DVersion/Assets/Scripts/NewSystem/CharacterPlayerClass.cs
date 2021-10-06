using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class CharacterPlayerClass : MonoBehaviour
{
    public CharacterController characterController;

    private void Start() {
       // Debug.Log(characterController.characterContainer.characterHealth.currentHealth);
    }
    private void Update() {
        

        if (Input.GetKeyDown(KeyCode.V)){
                        Debug.Log(characterController.tex);
        Debug.Log(characterController.text2);
                    Debug.Log(characterController.characterContainer.tex);
                    Debug.Log(characterController.characterContainer.characterHealth.currentHealth);

        }
    }
}

