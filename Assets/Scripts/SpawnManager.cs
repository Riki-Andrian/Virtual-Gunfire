using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float startDelay = 2;
    private float spawnInterval = 1f;
    private float spawnRange = 20;
    private int spawnCount;
    public int maxSpawn;
    private float spawnPosY = 2f;


    // Start is called before the first frame update
    void Start()
    {
     InvokeRepeating("GenerateSpawnPosition", startDelay, spawnInterval);
    
    }

    void GenerateSpawnPosition () {

        if(spawnCount>= maxSpawn)
        {
            CancelInvoke("GenerateSpawnPosition");
            return;
        }
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        //Instantiate(enemyPrefab, new Vector3( 0, 2, 4 ) + randomPos, enemyPrefab.transform.rotation);
        Instantiate(enemyPrefab, transform.position + randomPos, enemyPrefab.transform.rotation);
        spawnCount++;

       
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
