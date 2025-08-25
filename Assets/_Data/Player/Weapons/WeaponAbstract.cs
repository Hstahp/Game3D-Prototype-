using UnityEngine;

public class WeaponAbstract : SaiMonoBehaviour
{
    [SerializeField] protected AttackPoint attackPoint;
    public AttackPoint AttackPoint => attackPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttackPoint();
    }

    protected virtual void LoadAttackPoint()
    {
        if (attackPoint != null) return;
        this.attackPoint = transform.GetComponentInChildren<AttackPoint>();
        Debug.Log(transform.name + ": LoadAttackPoint", gameObject);
    }
}
