using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerClass : MonoBehaviour
{


    public List<Status> statuses;
    public string characterName = "";
    // turns
    public int actionEconomy = 3;
    public int bonusAction = 1;
    //Health
    public int maxHP;
    public int currentHP;
    public GameObject healthBarUI;
    public Slider slider;
    public PlayerInfoScritableObject playerInfoScritableObject;
    public int id = 0;
    public PlayerCombat playerCombat = null;
    public ClassTemplate playerChosenClass;
    public ClassInterface playerClassController;

    public event Action OnStatusUpdate;
    public event Action<GameObject> OnDeath;


    public void AddStatus(Status status)
    {
        statuses.Add(status);
        OnStatusUpdate?.Invoke();
    }
    public void RemoveStatus(Status status)
    {
        statuses.Remove(status);
        OnStatusUpdate?.Invoke();
    }





    void Start()
    {




        playerClassController = playerChosenClass;

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


    public int GetAC()
    {
        return this.playerChosenClass.playerStats.playerStats.generalStats[4].value;


    }


}



