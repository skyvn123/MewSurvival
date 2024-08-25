using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDespawn
{
    void DespawnObject();
}

public interface ITriggerEnter
{
    void OnTriggerEnter(Collider collision);
}

public interface IAfterTrigger
{
    void AfterTrigger();
}

public interface ITriggerExit
{
    void OnTriggerExit(Collider collision);
}
