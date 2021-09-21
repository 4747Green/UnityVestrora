using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float health;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;

    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();
        
        if(health >= 0.00){
            // set dead icon
        }

        if(health <= 0){
            healthBarUI.SetActive(true);
        }

        

    }

    float CalculateHealth(){
        return health / maxHealth;

    }
}
