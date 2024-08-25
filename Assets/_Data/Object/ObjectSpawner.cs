using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : Spawer
{
    protected static ObjectSpawner instance;
    public static ObjectSpawner Instance { get => instance; }
    public static string Object_axe = "Object_axe";
    public static string Object_baseball_bat = "Object_baseball_bat";
    public static string Object_knife = "Object_knife";
    public static string GoldCoin = "GoldCoin";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.Log("Only 1 ObjectSpawner allow");
        ObjectSpawner.instance = this;
    }
}
