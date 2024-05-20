using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject blackEnemyPrefab;
    public GameObject whiteEnemyPrefab;
    public float spawnRate = 4f;
    public float spawnAreaWidth = 3f;
    public Transform player;

    private float nextSpawnTime = 3f;

    void Update()
    {
        if (player != null)
        {
            FollowPlayer();
        }

        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + 4f / spawnRate;
        }
    }
    void FollowPlayer()
    {
        Vector3 newPos = transform.position;
        newPos.y = player.position.y + Camera.main.orthographicSize + 1f;
        transform.position = newPos;
    }
    void SpawnEnemy()
    {
        float spawnX = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, 0f);

        GameObject enemyPrefab = Random.value > 0.5f ? blackEnemyPrefab : whiteEnemyPrefab;
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        if (enemyPrefab == blackEnemyPrefab)
        {
            enemy.GetComponent<Enemy>().enemyType = "black";
        }
        else
        {
            enemy.GetComponent<Enemy>().enemyType = "white";
        }
    }
}
