using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private float enemySpawnWaitTime = 2f;
    [SerializeField] private float powerUpSpawnWaitTime = 15f;


    private void Start() {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnEnemy() {
        WaitForSeconds wait = new WaitForSeconds(enemySpawnWaitTime);
        while (true) {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-4.298f, 4.298f), transform.position.y, 0), transform.rotation);
            yield return wait;
        }
    }

    IEnumerator SpawnPowerUp() {
        WaitForSeconds wait = new WaitForSeconds(powerUpSpawnWaitTime);
        while (true) {
            Instantiate(powerUpPrefab, new Vector3(Random.Range(-4.298f, 4.298f), transform.position.y, 0), transform.rotation);
            yield return wait;
        }
    }
}
