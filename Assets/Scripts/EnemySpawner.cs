using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private float initialEnemySpawnWaitTime = 2f;
    [SerializeField] private float powerUpSpawnWaitTime = 30f;
    [SerializeField] private float decreaseRate = 0.02f; // Rate at which enemySpawnWaitTime decreases
    [SerializeField] private float minEnemySpawnWaitTime = 1f; // Minimum time between enemy spawns

    [SerializeField] private float enemySpawnWaitTime;

    private void Start()
    {
        enemySpawnWaitTime = initialEnemySpawnWaitTime;
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-4.298f, 4.298f), transform.position.y, 0), transform.rotation);

            // Decrease the spawn time gradually
            if (enemySpawnWaitTime > minEnemySpawnWaitTime)
            {
                enemySpawnWaitTime -= decreaseRate;
            }

            yield return new WaitForSeconds(enemySpawnWaitTime);
        }
    }

    IEnumerator SpawnPowerUp()
    {
        WaitForSeconds wait = new WaitForSeconds(powerUpSpawnWaitTime);
        while (true)
        {
            Instantiate(powerUpPrefab, new Vector3(Random.Range(-4.298f, 4.298f), transform.position.y, 0), transform.rotation);
            yield return wait;
        }
    }
}