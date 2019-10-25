using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : DamageSystem
{
    public float velocity = 10f;
    [SerializeField] Rigidbody rigidbody = null;
    void Start()
    {
        rigidbody.AddForce(transform.forward * velocity * Time.deltaTime, ForceMode.Impulse);
        Destroy(gameObject, 2f);
    }

    public override void OnDamage()
    {
        Destroy(gameObject);
    }
}
