using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] private List<GameObject> EnemyPrefabs;
    [SerializeField] private Vector3 spawnOffset;
    [SerializeField] private float spawnTimer;

    void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            SpawnEnemy();
            spawnTimer = Random.Range(1f, 5f);
        }
    }

    private void SpawnEnemy()
    {
        Vector3 randomOffset = new Vector3(0f, Random.Range(-5f, 5f), 0f);
        Debug.Log("Spawning Enemy");
        Vector3 spawnPosition = transform.position + spawnOffset + randomOffset;

        int randomIndex = Random.Range(0, EnemyPrefabs.Count);
        GameObject enemyToSpawn = EnemyPrefabs[randomIndex];
        Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
    }
}