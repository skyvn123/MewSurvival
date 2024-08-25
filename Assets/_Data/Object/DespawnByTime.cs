using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float Lifetime = 5f;
    protected override bool CanDespawn()
    {
        Lifetime -= Time.fixedDeltaTime;
        if (Lifetime > 0) return false;
        Lifetime = 5f;
        return true;
    }
}
