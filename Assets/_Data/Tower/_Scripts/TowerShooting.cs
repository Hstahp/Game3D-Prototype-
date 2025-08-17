using TMPro;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected float rotationSpeed = 50f;
    [SerializeField] protected EnemyController target;
    [SerializeField] protected BulletSpawner bulletSpawner;
    [SerializeField] protected Bullet bullet;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.TargetLoading), 1f);
    }
    protected void FixedUpdate()
    {
        this.Looking();
        this.Shooting();
    }
  
    protected virtual void TargetLoading()
    {
        Invoke(nameof(this.TargetLoading), 1f);
        this.target = this.towerController.TowerTargeting.Nearest;
    }

    protected virtual void Looking()
    {
        if (this.target == null) return;

        Vector3 directionToTarget = this.target.TowerTargetable.transform.position - this.towerController.Rotator.position;
        Vector3 newDirection = Vector3.RotateTowards(
            this.towerController.Rotator.forward,
            directionToTarget,
            rotationSpeed * Time.fixedDeltaTime,
            0.0f
        );

        // Apply the new direction to the rotator
        this.towerController.Rotator.rotation = Quaternion.LookRotation(newDirection);

        //this.towerCtrl.Rotator.LookAt(this.target.TowerTargetable.transform.position);
    }
    protected virtual void Shooting()
    {
        if(this.target == null) return;
        //Spawner
        this.towerController.BulletSpawner.Spawn(this.towerController.Bullet);
    }
}
