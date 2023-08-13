using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnWaitTime = 2f;

    private void Start() {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy() {
        WaitForSeconds wait = new WaitForSeconds(spawnWaitTime);
        while (true) {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-4.298f, 4.298f), transform.position.y, 0), transform.rotation);
            yield return wait;
        }
    }
}
