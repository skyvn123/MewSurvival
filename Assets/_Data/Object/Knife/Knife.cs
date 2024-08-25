using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour, IDespawn, ITriggerEnter, IAfterTrigger, ITriggerExit
{
    [SerializeField] protected float damage = 15f;

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
        AfterTrigger();
    }

    public void AfterTrigger()
    {
        this.GetComponent<Collider>().enabled = false;
        Debug.Log("Despawn after 1f" + this.transform.parent.name);
        Invoke(nameof(DespawnObject), 1f);
    }
    public void DespawnObject()
    {
        this.GetComponent<Collider>().enabled = true;
        ObjectSpawner.Instance.Despawn(transform.parent);
    }
}
