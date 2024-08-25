using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour, ITriggerEnter, ITriggerExit, IDespawn
{

    [SerializeField] protected int point = 10;

    public void OnTriggerEnter(Collider collision)
    {
        var hp = collision.gameObject.GetComponent<IGetPoint>();
        if (hp != null)
        {
            hp.GetPoint(point);
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
