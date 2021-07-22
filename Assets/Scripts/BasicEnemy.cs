using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    [SerializeField] private GameObject coinPrefab;
    private float droppedCoinMaxRange = 2;

    public override void Die()
    {
        DropCoins();
        base.Die();
    }

    private void DropCoins()
    {
        for (int i = 0; i < Random.Range(1, 6); i++)
        {
            Vector3 coinPosition = transform.position + new Vector3(
                Random.Range(-droppedCoinMaxRange, droppedCoinMaxRange),
                0,
                Random.Range(-droppedCoinMaxRange, droppedCoinMaxRange)
            );
            CreateCoin(coinPosition);
        }
    }

    private void CreateCoin(Vector3 position)
    {
        Instantiate(
            coinPrefab,
            position,
            coinPrefab.transform.rotation
        );
    }
}
