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
    protected virtual void FixedUpdate()
    {
        this.RemoveDeadOne();
    }
    protected virtual void Spawning()
    {
        Invoke(nameof(this.Spawning), this.spawnSpeed);
        if (this.spawnedEnemies.Count > this.maxSpawn) return; 
        EnemyController prefab = this.enemyManagerCtrl.EnemyPrefabs.GetRandom();

        this.enemyManagerCtrl.EnemySpawner.Spawn(prefab, transform.position);
        EnemyController newEnemy = this.enemyManagerCtrl.EnemySpawner.Spawn(prefab, transform.position);
        newEnemy.gameObject.SetActive(true);

        this.spawnedEnemies.Add(newEnemy);  
        Debug.Log("Spawning");
    }
   
    protected virtual void RemoveDeadOne()
    {
        foreach(EnemyController enemyController in this.spawnedEnemies)
        {
            if (enemyController.EnemyDamageReceiver.IsDead())
            {
                this.spawnedEnemies.Remove(enemyController);
                return;
            }
        }
    }
}
