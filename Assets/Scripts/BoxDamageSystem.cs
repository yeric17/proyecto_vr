using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDamageSystem : DamageSystem
{
    public override void OnDamage(){
        Destroy(gameObject);
    }
}
