using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected float rotationSpeed = 50f;
    [SerializeField] protected int  currentFirePoint = 0;
    [SerializeField] protected float shootSpeed = 1f;
    [SerializeField] protected float targetLoadSpeed = 1f;
    [SerializeField] protected EnemyController target;
    [SerializeField] protected BulletSpawner bulletSpawner;
    [SerializeField] protected Bullet bullet;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.TargetLoading), this.targetLoadSpeed);
        Invoke(nameof(this.Shooting), this.shootSpeed);
    }
    protected void FixedUpdate()
    {
        this.Looking();
    }
  
    protected virtual void TargetLoading()
    {
        Invoke(nameof(this.TargetLoading), this.targetLoadSpeed);
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
        Invoke(nameof(this.Shooting), this.shootSpeed);
        if (this.target == null) return;
        FirePoint firePoint = this.GetFirePoint();
        Bullet newBullet = this.towerController.BulletSpawner.Spawn(this.towerController.Bullet, firePoint.transform.position);
        Vector3 rotatorDirection = this.towerController.Rotator.transform.forward;
        newBullet.transform.forward = rotatorDirection;
        newBullet.gameObject.SetActive(true);
    }
    protected virtual FirePoint GetFirePoint()
    {
        FirePoint firePoint = this.towerController.FirePoints[this.currentFirePoint];
        this.currentFirePoint++;
        if (this.currentFirePoint == this.towerController.FirePoints.Count) this.currentFirePoint = 0;
        return firePoint;
    }
}
