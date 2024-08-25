using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected float distanceLimit = 80f;
    [SerializeField] protected Camera mainCamera;
    protected override void LoadComponents()
    {
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if(this.mainCamera!=null) return;
        this.mainCamera = FindObjectOfType<Camera>();
    }

    protected override bool CanDespawn()
    {
       if(distanceLimit > GetDistancebtwCamera()) return false;
       return true;
    }

    protected virtual float GetDistancebtwCamera()
    {
        this.distance = Vector3.Distance(transform.position, mainCamera.transform.position);
        return distance;
    }
}
