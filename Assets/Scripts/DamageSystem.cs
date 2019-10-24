using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class DamageSystem : MonoBehaviour
{
    [SerializeField] int damagePoints = 10;
    [SerializeField] private BoxCollider triggerArea = null;

    private void Start() {
        if(triggerArea == null){
            triggerArea = GetComponent<BoxCollider>();
        }
        triggerArea.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<HealthSystem>()) {
            other.gameObject.GetComponent<HealthSystem>().Damage(damagePoints);
            OnDamage();
        }
    }

    public virtual void  OnDamage(){

    }

}
