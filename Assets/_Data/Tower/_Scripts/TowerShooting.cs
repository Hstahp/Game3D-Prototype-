using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected EnemyController target;

    protected void FixedUpdate()
    {
        this.LookAtTarget();
        //this.ShootAtTarget();
    }
    protected virtual void LookAtTarget()
    {
        if (this.target == null) return;
        this.towerController.Rotator.LookAt(this.target.TowerTargetable.transform.position);
    }
}
