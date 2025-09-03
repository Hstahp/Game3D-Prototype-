using UnityEngine;

public class TowerManager : SaiSingleton<TowerManager>
{
    [SerializeField] protected TowerCode newTowerId = TowerCode.NoTower;
    [SerializeField] protected TowerController towerPrefab;
    [SerializeField] protected bool towerPlace = false;
    protected virtual void LateUpdate()
    {
        this.ShowTowerToPlace();
    }

    protected virtual void ShowTowerToPlace()
    {
        if (this.towerPlace) return;
        this.newTowerId = MapKeyCodeToTower(InputHotKey.Instance.KeyCode);
        if (this.newTowerId == TowerCode.NoTower)
        {
            if(this.towerPrefab != null) this.towerPrefab.SetActive(false);
            this.towerPrefab = null;
            return;
        }
        if (this.towerPrefab == null)
        {
            this.towerPrefab = this.GetTowerPrefab(this.newTowerId);
            if (this.towerPrefab == null) return;
            this.towerPrefab.TowerShooting.Disable();
            this.towerPrefab.SetActive(true);
        }
        this.towerPrefab.transform.position = PlayerController.Instance.CrosshairPointer.transform.position;

        if (InputHotKey.Instance.IsPlaceTower) this.PlaceTower();
    }
    
    protected virtual void PlaceTower()
    {
        this.towerPlace = true;
        TowerController newTower = this.Spawn(this.towerPrefab);
        newTower.TowerShooting.Active();
        newTower.SetActive(true);

        //this.towerPrefab.SetActive(false);
        //this.newTowerId = TowerCode.NoTower;
        //this.towerPrefab = null;
        Invoke(nameof(this.PlaceFinish), 0.5f);
    }

    protected virtual void PlaceFinish()
    {
      
        this.towerPlace = false;
    }

    protected virtual TowerController GetTowerPrefab(TowerCode towerCode)
    {
        return TowerSpawnerCtrl.Instance.TowerPrefabs.GetByName(towerCode.ToString());
    }

    protected virtual TowerController Spawn(TowerController prefab)
    {
        return TowerSpawnerCtrl.Instance.Spawner.Spawn(prefab, prefab.transform.position);
    }

    protected TowerCode MapKeyCodeToTower(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.Alpha1: return TowerCode.MachineGun;
            case KeyCode.Alpha2: return TowerCode.LaserGun;
            default: return TowerCode.NoTower;
        }
    }
}
