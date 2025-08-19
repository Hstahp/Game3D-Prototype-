using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider))]    
public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected CapsuleCollider capsuleCollider;
    [SerializeField] protected EnemyController enemyController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCapsuleCollider();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider> ();
        this.capsuleCollider.center = new Vector3(0, 1, 0);
        this.capsuleCollider.radius = 0.3f;
        this.capsuleCollider.height = 1.5f;
        this.capsuleCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadCapsuleCollider", gameObject);
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyController != null) return;
        this.enemyController = transform.GetComponentInParent<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected override void OnDead()
    {
        base.OnDead();
        this.enemyController.Animator.SetBool("isDead", this.isDead);
    }
    protected override void OnHurt()
    {
        base.OnHurt();
        this.enemyController.Animator.SetTrigger("isHurt");
    }
}
