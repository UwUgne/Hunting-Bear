using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] Spawnpoints;
    public GameObject[] enemies;

    public float spawnInterval = 2f;
    public int SpawnRate = 1;
    public float bigCountdown = 5f;
   
    private float currentSpawnTime = 0f;
    private float Timu = 0f;
    private float currentTime = 0f;
    private float increaseinrate = 20f;
    void Update()
    {
        currentSpawnTime += Time.deltaTime;
        currentTime += Time.deltaTime;
        Timu += Time.deltaTime;

        if (currentSpawnTime >= spawnInterval)
        {   
                Spawn();
                currentSpawnTime = 0;
        }

        if (currentTime >= bigCountdown && spawnInterval > 0.9f)
        {
            spawnInterval -= .1f;
            currentTime = 0;
        }

        if (Timu >= increaseinrate)
        {
            SpawnRate += 1;
            Timu = 0;
        }
    }
    void Spawn()
    {
        for (int i = 0; i < SpawnRate; i++)
        {
            Transform sp = Spawnpoints[Random.Range(0, Spawnpoints.Length)];
            Instantiate(enemies[Random.Range(0, enemies.Length)], sp.position, sp.rotation);
        }
    }

}