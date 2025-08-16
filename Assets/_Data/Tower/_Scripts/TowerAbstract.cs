using Unity.VisualScripting;
using UnityEngine;

public abstract class TowerAbstract : SaiMonoBehaviour
{
    [SerializeField] protected TowerController towerController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerController();
    }
    protected virtual void LoadTowerController()
    {
        if (this.towerController != null) return;
        this.towerController = transform.parent.GetComponent<TowerController>();
        Debug.Log(transform.name + ": LoadTowerController", gameObject);
    }
}
