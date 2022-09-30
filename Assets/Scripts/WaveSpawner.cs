using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int HowMuchSpawned;

    public GameObject enemy;
    public Transform[] Spawners;

    

    public int WaveNumber;

    private int HowMuchToSpawn = 6;
    private float nextSpawnTime = 0f;

    private float WaveCountdown = 5f;


    // Start is called before the first frame update
    void Start()
    {
        WaveNumber = 1;
        HowMuchSpawned = 0;
        Spawners = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if (WaveCountdown<=0)
        {
            if (HowMuchToSpawn > 0)
            {
                if (Time.time > nextSpawnTime)
                {
                    SpawnEnemy();
                    HowMuchToSpawn--;
                    nextSpawnTime = Time.time + 0.5f;
                }
            }
            else
            {
                if (HowMuchSpawned==0)
                {
                    WaveNumber++;
                    HowMuchToSpawn = WaveNumber * 2 + 4;
                    WaveCountdown = 5f;
                }
            }
        }
        else
        {
            WaveCountdown-=Time.deltaTime;
        }
    }

    void SpawnEnemy()
    {
        HowMuchSpawned++;
        Vector3 spawnPos = Spawners[Random.Range(0, Spawners.Length)].position;

        GameObject Obj = Instantiate(enemy, spawnPos, new Quaternion());
        Enemy enemyObj = Obj.GetComponent<Enemy>();

        enemyObj.MaxChaseDistance = 10000f;
        enemyObj.AwakeDistance = 10000f;
        enemyObj.IsAwake = true;
        enemyObj.MoveSpeed = 4 + WaveNumber / 10;
        enemyObj.Damage = 10 + WaveNumber;
        enemyObj.Health = 30 + WaveNumber * 2;
    }
}
