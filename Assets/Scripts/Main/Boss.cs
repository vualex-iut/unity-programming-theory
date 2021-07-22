using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy // INHERITANCE
{
    [SerializeField] private GameObject[] enemiesToSummonPrefabs;
    private float summonMaxRange = 3;

    public override void Die() // POLYMORPHISM
    {
        SummonEnemies();
        base.Die();
    }

    public override void DisplayDeathMessage() // POLYMORPHISM
    {
        Debug.Log($"Boss '{_name}' died.");
    }

    private void SummonEnemies() // ABSTRACTION
    {
        for (int i = 0; i < enemiesToSummonPrefabs.Length; i++)
        {
            Vector3 summonPosition = transform.position + new Vector3(
                Random.Range(-summonMaxRange, summonMaxRange),
                0,
                Random.Range(-summonMaxRange, summonMaxRange)
            );
            SummonEnemy(enemiesToSummonPrefabs[i], summonPosition, i + 1);
        }
    }

    private void SummonEnemy(GameObject enemyPrefab, Vector3 position, int enemyNumber) // ABSTRACTION
    {
        GameObject enemy = Instantiate(
            enemyPrefab,
            position,
            enemyPrefab.transform.rotation
        );
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.Name = _name + "'s Minion " + enemyNumber;
    }
}
