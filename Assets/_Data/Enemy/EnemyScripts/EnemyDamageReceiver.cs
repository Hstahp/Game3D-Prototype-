using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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
        this.capsuleCollider.enabled = false;
        this.RewardOnDead();
        Invoke(nameof(this.Disappear), 3f);
    }
    protected override void OnHurt()
    {
        base.OnHurt();
        this.enemyController.Animator.SetTrigger("isHurt");
    }
    protected virtual void Disappear()
    {
        this.enemyController.Despawn.DoDespawn();
    }
    protected override void OnReborn()
    {
        base.OnReborn();
        this.capsuleCollider.enabled = true;
    }

    protected virtual void RewardOnDead()
    {
        //ItemInventory item = new();
        //item.itemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold);
        //item.itemCount = 1;
        //InventoryManager.Instance.Monies().AddItem(item);
        ItemsDropManager.Instance.DropMany(ItemCode.Gold, 10, transform.position);
        ItemsDropManager.Instance.DropMany(ItemCode.PotionMana, 1, transform.position);
        ItemsDropManager.Instance.DropMany(ItemCode.PlayerExp, 10, transform.position);

    }
}
