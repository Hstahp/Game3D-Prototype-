using UnityEngine;
using UnityEngine.AI;

public class ProjectTile2Ctrl : EffectFlyAbstract
{
    [SerializeField] protected DamageSender damageSender;
    public override string GetName()
    {
        return "ProjectTile2";
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<DamageSender>();
        this.damageSender.SetDamage(4);
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }
}