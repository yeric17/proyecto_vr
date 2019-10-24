using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthSystem : MonoBehaviour, ISystemHealth
{
    [SerializeField] protected int healthPoints = 100;
    [SerializeField] protected int minHealth = 0;
    [SerializeField] protected int maxHealth = 100;
    public void Damage(int d)
    {
        if(healthPoints - d < minHealth){
            healthPoints = minHealth;
        }
        else {
            healthPoints -= d;
        }
        OnDamage();
        if(healthPoints == minHealth) OnEndHealth();
        
    }
    public void Health(int h) {
        if(healthPoints + h > maxHealth){
            healthPoints = maxHealth;
        }
        else {
            healthPoints += h;
        }
    }

    protected virtual void OnDamage(){

    }
    protected virtual void OnEndHealth(){

    }
}

