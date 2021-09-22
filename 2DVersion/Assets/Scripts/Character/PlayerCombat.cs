using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerCombat :  MonoBehaviour


{
    // Start is called before the first frame update
    public bool inCombat;
    public enum PlayerAttackType { Melee, Ranged };
    public PlayerAttackType playerAttackType;
    public PlayerClass player;
    public int actionsEconomyThisTurn;
    public GameObject targetedEnemy = null;
    public float attackRange;
    public bool heroPlayer;
    RaycastHit hit;
    public PlayerCombatHandler playerCombatHandler;
    public CombatActionsHandler combatActionsHandler;

    public event Action OnCharacterStatusChange;



    private void Awake() {
         playerCombatHandler = new PlayerCombatHandler(3,this);
         combatActionsHandler = new CombatActionsHandler(this);
    }
    
    public bool IsTurnInProgress(){
       return this.playerCombatHandler.GetTurnInProcess();
    }



    public void EnemyTurn()
    {
        
        GameObject self = GameObject.FindGameObjectWithTag("Enemy");
        self.GetComponent<SimpleEnemyCombatScript>().FindAndSetPlayerAsTarget();
        self.GetComponent<SimpleEnemyCombatScript>().CombatTurnAction();

    }

    public bool IsHeroPlayer()
    {
        return heroPlayer;
    }


    public void AttackRollaAainstArmorClass()
    {     

    }

    public void CallToTakeCombatAction(CombatActionsHandler.ActionTypeState state){
            
       this.combatActionsHandler.CombatActionCall(state);
    }


}
