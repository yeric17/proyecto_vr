using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class DamageSystem : MonoBehaviour
{
    [SerializeField] int damagePoints = 10;
    [SerializeField] private BoxCollider triggerArea = null;
    [SerializeField] private string tagTarget = "Player";

    private void Start() {
        if(triggerArea == null){
            triggerArea = GetComponent<BoxCollider>();
        }
        triggerArea.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.tag);
        
            if (other.gameObject.CompareTag(tagTarget)) {
                Debug.Log("Colision 2");
                other.gameObject.GetComponent<HealthSystem>().Damage(damagePoints);
                OnDamage();
            }
            
        
    }

    public virtual void  OnDamage(){

    }

}
