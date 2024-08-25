using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawer : MyMonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }
    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0 ) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach(Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
       this.HidePrefabs();
       Debug.Log(transform.name + " Load Component Prefab");
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null ) return;
        holder = transform.Find("Holder");
        Debug.Log(transform.name + " Load Component Holder");
    }


    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
           prefab.gameObject.SetActive(false);
        }
    }
    public virtual Transform Spawn(string prefabName,Vector3 spawnPos,Quaternion rotation)
    {
        Transform prefab = GetPrefabbyName(prefabName);
        if (prefab == null) return null;
        Transform newprefab = this.GetObjFromPool(prefab);
        newprefab.SetPositionAndRotation(spawnPos, rotation);
        newprefab.parent = this.holder;
        return newprefab;
    }
    protected virtual Transform GetObjFromPool(Transform prefab)
    {
        foreach(Transform poolObj in this.poolObjs)
        {
            this.poolObjs.Remove(poolObj);
            return poolObj;
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
    protected virtual Transform GetPrefabbyName(string prefabName)
    {
        foreach (Transform prefab in prefabs)
        {
            if(prefab.name == prefabName)
            return prefab;
        }
        Debug.Log("Prefab not found");
        return null;
    }
}
