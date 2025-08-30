using UnityEngine;

public class TowerLevel : LevelAbstract
{
    [SerializeField] protected TowerController towerController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }

    protected virtual void LoadTowerCtrl()
    {
        if (this.towerController != null) return;
        this.towerController = GetComponentInParent<TowerController>();
        Debug.Log(transform.name + ": LoadTowerCtrl", gameObject);
    }

    protected override bool DeductExp(int exp)
    {
        return this.towerController.TowerShooting.DeductKillCount(exp);
    }

    protected override int GetCurrentExp()
    {
        return this.towerController.TowerShooting.KillCount;
    }

    protected override int GetNextLevelExp()
    {
        return this.nextLevelExp = this.currentLevel * 2;
    }

}
