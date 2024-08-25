using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baseball_bat : MonoBehaviour, IDespawn, ITriggerEnter,ITriggerExit
{
    [SerializeField] protected float damage = 30f;

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
