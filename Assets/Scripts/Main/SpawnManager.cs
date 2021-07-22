using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static string[] possibleBossNames = { "Thor", "Zeus", "Athena", "Medusa" };
    [SerializeField] private GameObject basicEnemyPrefab;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private float bossSpawnRate;
    [SerializeField] private float maxXSpawnRange = 50;
    [SerializeField] private float maxZSpawnRange = 25;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 2);
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-maxXSpawnRange, maxXSpawnRange),
            2,
            Random.Range(-maxZSpawnRange, maxZSpawnRange)
        );

        if (Random.value <= bossSpawnRate)
        {
            string bossName = GetRandomBossName() + " from " + Random.Range(-3000, 2022);
            SpawnEnemy(spawnPosition, bossPrefab, bossName);
        }
        else
        {
            string basicEnemyName = "Enemy_" + Random.Range(2, 100000);
            SpawnEnemy(spawnPosition, basicEnemyPrefab, basicEnemyName);
        }
    }

    private void SpawnEnemy(Vector3 position, GameObject prefab, string name)
    {
        GameObject enemy = Instantiate(prefab, position, prefab.transform.rotation);
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.Name = name;
    }

    private static string GetRandomBossName()
    {
        int bossNameIndex = Random.Range(0, possibleBossNames.Length);
        return possibleBossNames[bossNameIndex];
    }
}
