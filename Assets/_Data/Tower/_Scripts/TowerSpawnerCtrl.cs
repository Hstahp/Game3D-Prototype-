using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawnerCtrl : SaiSingleton<TowerSpawnerCtrl>
{
    [SerializeField] protected TowerSpawner spawner;
    public TowerSpawner Spawner => spawner;
    [SerializeField] protected TowerPrefabs towerPrefabs;
    public TowerPrefabs TowerPrefabs => towerPrefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerSpawner();
        this.LoadTowerPrefabs();
    }

    protected virtual void LoadTowerSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<TowerSpawner>();
        Debug.Log(transform.name + ": LoadEffectSpawner", gameObject);
    }

    protected virtual void LoadTowerPrefabs()
    {
        if (this.towerPrefabs != null) return;
        this.towerPrefabs = GetComponentInChildren<TowerPrefabs>();
        Debug.Log(transform.name + ": LoadTowerPrefabs", gameObject);
    }
}