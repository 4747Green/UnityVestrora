using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUserClass : MonoBehaviour
{

    public PlayerClass playerClass;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (this.playerClass.playerCombat != null)
            {
                if (this.playerClass.playerCombat.targetedEnemy != null)
                {
                    Debug.Log("call to attack");
                    this.playerClass.playerCombat.CallToTakeCombatAction(CombatActionsHandler.ActionTypeState.MeeleAttack);

                }
                else
                {
                    Debug.Log("No Target Select");

                }

            }
            else
            {
                Debug.Log("playerCombat not assigned");
            }
        }


        if (Input.GetKeyDown(KeyCode.T))
        {

            this.playerClass.playerChosenClass.holder.RefreshAllSkillChagres();
        }



        if (Input.GetKeyDown(KeyCode.C))
        {
            if (GameManager.Instance.State == GameState.FreeRoam)
            {
                GameManager.Instance.UpdateGameState(GameState.Combat);
            }
            else
            {

            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {

            this.playerClass.playerInfoScritableObject.Arsenal.HeavyArmor = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameManager.Instance.UpdateGameState(GameState.Dialouge);

        }
    }
}
