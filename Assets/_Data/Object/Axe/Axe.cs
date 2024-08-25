using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Axe : MonoBehaviour, IDespawn, ITriggerEnter, ITriggerExit
{
    [SerializeField] protected float damage = 10f;

    public void OnTriggerEnter(Collider collision)
    {
        var hp = collision.gameObject.GetComponent<IHealth>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
        }
    }
    public void OnTriggerExit(Collider collision) 
    {
        DespawnObject();
    }
    public void DespawnObject()
    {
        ObjectSpawner.Instance.Despawn(transform.parent);
    }

}
