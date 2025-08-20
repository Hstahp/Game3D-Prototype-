using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : EnemyManagerAbstract
{
    [SerializeField] protected float spawnSpeed = 1f;
    [SerializeField] protected int maxSpawn = 10;
    protected List<EnemyController> spawnedEnemies = new();

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Spawning),this.spawnSpeed);
    }

    protected virtual void Spawning()
    {
        Invoke(nameof(this.Spawning), this.spawnSpeed);
        EnemyController prefab = this.enemyManagerCtrl.EnemyPrefabs.GetRandom();

        this.enemyManagerCtrl.EnemySpawner.Spawn(prefab, transform.position);
        EnemyController newEnemy = this.enemyManagerCtrl.EnemySpawner.Spawn(prefab, transform.position);
        newEnemy.gameObject.SetActive(true);
        Debug.Log("spawning");
    }
   
}
