using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUserClass : MonoBehaviour
{

    public PlayerClass playerClass;
    public List<KeyBinding> listOfKeyCodes;
    private KeyBindState keyState;

    // Start is called before the first frame update


    public void InputStateSwitch(KeyBindState keyBindState)
    {

        keyState = keyBindState;

        switch (keyBindState)
        {
            case KeyBindState.Attack:
                AttackInput();
                break;
            case KeyBindState.RefreshAllSkillChagres:
                RefreshAllSkillChagresInput();
                break;
            case KeyBindState.StartCombatTester:
                StartCombatInput();
                break;
            case KeyBindState.StartDialogueTester:
                GameStateDialougeInput();
                break;
            case KeyBindState.TestDebugLog:
                TestDebugLog();
                break;
            default:
                break;
        }




    }

    void AttackInput()
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

    void RefreshAllSkillChagresInput()
    {
        this.playerClass.playerChosenClass.holder.RefreshAllSkillChagres();

    }

    void StartCombatInput()
    {
        if (GameManager.Instance.State == GameState.FreeRoam)
        {
            GameManager.Instance.UpdateGameState(GameState.Combat);
        }
        else
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        foreach (var item in listOfKeyCodes) if (Input.GetKeyDown(item.key)) InputStateSwitch(item.keyBindState);

    }

    private static void GameStateDialougeInput()
    {
        GameManager.Instance.UpdateGameState(GameState.Dialouge);
    }


    [System.Serializable]
    public class KeyBinding
    {
        public KeyCode key;
        public string name;
        public KeyBindState keyBindState;
        public KeyBinding(KeyCode key, string name, KeyBindState keyBindState)
        {
            this.key = key;
            this.name = name;
            this.keyBindState = keyBindState;
        }

    }

    void TestDebugLog()
    {
        Debug.Log("Test Debug Log Input");
    }

    public enum KeyBindState
    {
        StartCombatTester,
        StartDialogueTester,
        Attack,
        RefreshAllSkillChagres,
        TestDebugLog

    }
}
