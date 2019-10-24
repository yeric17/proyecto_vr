using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthSystem
{
    [SerializeField] Slider sliderHealth = null;

    private void Start(){
        sliderHealth.minValue = minHealth;
        sliderHealth.maxValue = maxHealth;
        sliderHealth.value = maxHealth;
    }
    protected override void OnDamage(){
        sliderHealth.value = healthPoints;
    }
}
