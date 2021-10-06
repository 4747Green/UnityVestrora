using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class CharacterHotbarUI : MonoBehaviour
{

    public GameObject hotbarContentWindow;
    public GameObject itemPrefab;

    //     public GameObject itemPrefab;

    private void Awake()
    {
        CharacterSpawner.OnCharacterCreation += CharacterCreation;

    }
    private void OnDestroy()
    {
        CharacterSpawner.OnCharacterCreation -= CharacterCreation;

    }

    public void CharacterCreation(CharacterController controller)
    {
        DrawHotbar(controller.characterContainer.characterAttacks.GetAttackList());

    }
    public void DrawHotbar(List<AttackTemp> attackList)
    {

        GameObject newObj;

        foreach (var item in attackList)
        {
            newObj = (GameObject)Instantiate(itemPrefab, hotbarContentWindow.transform, false);
            newObj.transform.parent = hotbarContentWindow.transform;


            newObj.GetComponent<HotbarItemReferences>().text.text = item.name;



        }


    }


}

