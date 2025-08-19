using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletController bulletController;
    [SerializeField] protected SphereCollider sphereCollider;
 
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.05f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletController != null) return;
        this.bulletController = transform.GetComponentInParent<BulletController>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }
    protected override  void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.bulletController.Bullet.Despawn.DoDespawn();

    }
}
