using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class EnemyClass : MonoBehaviour
{
    [Header("EnemyBasicStats")]
    public string EnemyTypeName;
    public int maxHP;
    public int currentHP;
    public int ac;
    public int speed;
    public int[] primaryStats = new int[6];

    [Header("Damage Resistances")]
    [Header("Damage Immunities")]
    [Header("Condition  Immunities")]

    [Header("Passives")]
    [Header("Actions")]
    public  List<AttackTemplate> attackList;
    public  List<AbilityTemplate> skillList;
    [Header("Reactions")]

    public GameObject healthBarUI;
    public Slider slider;
    public PlayerCombat playerCombat;
    public ClassInterface playerClassController;
    public event Action<GameObject> OnDeath;

    private EnemyType enemyType;

    public void CreateCharacter(EnemyType enemyType)
    {
        // this.enemyType = enemyType;
        //  EnemyTypeName = enemyType.DisplayName;
        //   maxHP = enemyType.EnemyInfoTest.hp;
        //   currentHP = enemyType.EnemyInfoTest.hp;


    }

    void Start()
    {


        SetUpInnitalHealth();







    }

    public int GetCurrentHP()
    {
        return currentHP;
    }
    void Update()
    {

    }

    public void SetUpInnitalHealth()
    {
        currentHP = maxHP;

        this.slider.maxValue = currentHP;
        this.slider.value = currentHP;
    }
    public void TakeDamage(int dmg)
    {
        Debug.Log("taking dmg");
        currentHP = currentHP - dmg;

        // check dead
        if (currentHP <= 0)
        {

            // set dead icon
        }
        //check if dmg taken show bar if true
        if (currentHP <= 0)
        {
            healthBarUI.SetActive(true);
        }
        slider.value = currentHP;
        DeathCheck();
    }

    private void DeathCheck()
    {
        if (currentHP <= 0)
        {
            OnDeath?.Invoke(this.gameObject);
        }

    }
    public void Heal(int healAmount)
    {
        // heal
        currentHP = currentHP + healAmount;
        //check if overheal and prevent
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        slider.value = currentHP;

    }



    public void Move()
    {

    }





}
