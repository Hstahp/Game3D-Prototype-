using UnityEngine;

public abstract class AttackAbstract : SaiMonoBehaviour
{
    [SerializeField] protected PlayerController playerController;
    protected void Update()
    {
        this.Attacking();
    }
    protected abstract void Attacking();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerController != null) return;
        this.playerController = transform.GetComponentInParent<PlayerController>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    protected virtual AttackPoint GetAttackPoint()
    {
        return this.playerController.Weapons.GetCurrentWeapon().AttackPoint;
    }
}
