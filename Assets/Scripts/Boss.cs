using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private GameObject[] enemiesToSummonPrefabs;
    private float summonMaxRange = 3;

    public override void Die()
    {
        SummonEnemies();
        base.Die();
    }

    public override void DisplayDeathMessage()
    {
        Debug.Log($"Boss {_name} died.");
    }

    private void SummonEnemies()
    {
        for (int i = 0; i < enemiesToSummonPrefabs.Length; i++)
        {
            Vector3 summonPosition = transform.position + new Vector3(
                Random.Range(-summonMaxRange, summonMaxRange),
                0,
                Random.Range(-summonMaxRange, summonMaxRange)
            );
            SummonEnemy(enemiesToSummonPrefabs[i], summonPosition);
        }
    }

    private void SummonEnemy(GameObject enemyPrefab, Vector3 position)
    {
        Instantiate(
            enemyPrefab,
            position,
            enemyPrefab.transform.rotation
        );
    }
}
