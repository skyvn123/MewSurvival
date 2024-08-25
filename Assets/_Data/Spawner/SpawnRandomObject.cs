
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpawnRandomObject : MyMonoBehaviour
{
    [SerializeField] protected bool isSpawn;
    [SerializeField] protected float spawnTime;
    [SerializeField] protected float spawnDelay = 1f;
    [SerializeField] protected float spawnCoinTime;
    [SerializeField] protected float spawnCoinDelay = 1f;
    [SerializeField] protected Vector3 PlayerPosition;
    [SerializeField] protected Vector3 SpawnPosition;
    [SerializeField] protected float minRadius = 10f; // min from player
    [SerializeField] protected float maxRadius = 20f;// max from player
    private Vector2 origin,pointToSpawnAt;
    protected override void Start()
    {
        base.Start();
        this.GetSpawnPosition();
    }
    private void FixedUpdate()
    {
        if(GameManager.Instance.gamestarted)
        {
            isSpawn = true;
            this.Spawning();
            this.SpawningCoin();
        }
    }

    protected virtual void SpawningCoin()
    {
        this.spawnCoinTime += Time.fixedDeltaTime; 
        if (this.spawnCoinTime < this.spawnCoinDelay) return;
        this.spawnCoinTime = 0;
        Vector2 RandonCoinPosition = RandomPointWithRadius(new Vector2(0,0),25);
        Vector3 CoinSpawnPosition = new Vector3(RandonCoinPosition.x, Random.Range(0f,2.5f), RandonCoinPosition.y);
        Transform newObject = ObjectSpawner.Instance.Spawn(ObjectSpawner.GoldCoin, CoinSpawnPosition, this.transform.rotation);
        if (newObject == null) return;
        newObject.gameObject.SetActive(true);
        Debug.Log("Spawn ==== " + newObject.name);
    }

    protected virtual void Spawning()
    {
        this.spawnTime += Time.fixedDeltaTime;
        if (!isSpawn) return;
        if (this.spawnTime < this.spawnDelay) return;
        this.spawnTime = 0;
        SpawningbyName(ObjectSpawner.Object_axe);
        SpawningbyName(ObjectSpawner.Object_baseball_bat);
        SpawningbyName(ObjectSpawner.Object_knife);
    }
    protected virtual void SpawningbyName(string objectname)
    {
        this.GetSpawnPosition();
        Transform newObject = ObjectSpawner.Instance.Spawn(objectname, SpawnPosition, this.transform.rotation);
        if (newObject == null) return;
        newObject.gameObject.SetActive(true);
        Debug.Log("Spawn ==== " + newObject.name);
    }
    protected virtual void GetSpawnPosition()
    {
        PlayerPosition = GameObject.Find("Player").transform.position;
        origin = new Vector2(PlayerPosition.x, PlayerPosition.z);
        pointToSpawnAt = RandomPointInAnnulus(origin, minRadius, maxRadius);
       // pointToSpawnAt = RandomPointWithRadius(origin,maxRadius);
        SpawnPosition = new Vector3(pointToSpawnAt.x, 0.5f, pointToSpawnAt.y);
    }

    public Vector2 RandomPointWithRadius(Vector2 origin, float radius)
    {
        //Random point in circle with radius
        Vector2 randomPoint = origin + Random.insideUnitCircle * radius * 0.5f;
        return randomPoint;
    }

    public Vector2 RandomPointInAnnulus(Vector2 origin, float minRadius, float maxRadius)
    {
        //Random point in circle with min max radius
        var randomDirection = (Random.insideUnitCircle * origin).normalized;

        var randomDistance = Random.Range(minRadius, maxRadius);

        var point = origin + randomDirection * randomDistance;

        return point;
    }


  
}
