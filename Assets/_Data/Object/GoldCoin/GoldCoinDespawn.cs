using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldConDespawn : DespawnByTime
{
    protected override void DespawnObject()
    {
        ObjectSpawner.Instance.Despawn(transform.parent);
    }
}
