using UnityEngine;

public class EnemyHp : SliderHp
{
    [SerializeField] protected EnemyController enemyController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyController != null) return;
        this.enemyController = GetComponentInParent<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected override float GetValue()
    {
        return (float)this.enemyController.EnemyDamageReceiver.CurrentHp / (float)this.enemyController.EnemyDamageReceiver.MaxHp;
    }
}
