using UnityEngine;

public abstract class AttackAbstract : SaiMonoBehaviour
{
    [SerializeField] protected PlayerController playerController;
    [SerializeField] protected EffectSpawner effectSpawner;
    [SerializeField] protected EffectPrefabs effectPrefabs;
    protected void Update()
    {
        this.Attacking();
    }
    protected abstract void Attacking();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
        this.LoadEffectSpawner();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerController != null) return;
        this.playerController = transform.GetComponentInParent<PlayerController>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    
    protected virtual void LoadEffectSpawner()
    {
        if (this.effectSpawner != null) return;
        this.effectSpawner = GameObject.FindAnyObjectByType<EffectSpawner>();   
        this.effectPrefabs = GameObject.FindAnyObjectByType<EffectPrefabs>();
        Debug.Log(transform.name + ": LoadEffectSpawner", gameObject);
    }

    protected virtual AttackPoint GetAttackPoint()
    {
        return this.playerController.Weapons.GetCurrentWeapon().AttackPoint;
    }
}
