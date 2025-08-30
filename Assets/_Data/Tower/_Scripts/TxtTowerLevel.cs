using TMPro;
using UnityEngine;

public class TxtTowerLevel : TxtLevel
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

  
    protected override string GetLevel()
    {
        return this.towerController.Level.CurrentLevel.ToString(); 
    }
}
