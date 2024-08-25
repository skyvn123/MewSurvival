using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDespawn : DespawnByDistance
{
    protected override void DespawnObject()
    {
        ObjectSpawner.Instance.Despawn(transform.parent);
    }
}
