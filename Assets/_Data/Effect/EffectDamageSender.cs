using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public  class EffectDamageSender : DamageSender
{
    [SerializeField] protected EffectController effectController;
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadEffectController();
    }
    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.05f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }
    protected virtual void LoadEffectController()
    {
        if (this.effectController != null) return;
        this.effectController = transform.GetComponentInParent<EffectController>();
        Debug.Log(transform.name + ": LoadEffectController", gameObject);
    }
    protected override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.effectController.Despawn.DoDespawn();
    }
}
