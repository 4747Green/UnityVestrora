using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CharacterHealthHandler
{



    public GameObject healthBarUI;
    public Slider slider;

    public event Action<GameObject> OnDeath;


    public void SetUpInnitalHealth(int hp)
    {
        this.slider.maxValue = hp;
        this.slider.value = hp;
    }
    public void DecreaseSliderValue(int amount)
    {
        slider.value -= amount;
    }


    public void IncreaseSliderValue(int amount)
    {
        slider.value += amount;
    }
    public void CorrectIllegalSliderValues(){
        if (slider.value > 0)
        {
            slider.value =0;
        }

        if (slider.value < slider.maxValue)
        {
            slider.value =slider.maxValue;
        }
    }
}   
