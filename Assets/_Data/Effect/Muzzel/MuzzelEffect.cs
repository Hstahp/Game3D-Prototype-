using UnityEngine;
using UnityEngine.AI;

public class MuzzleEffect : SaiMonoBehaviour
{
    [SerializeField] protected MuzzleCode muzzle;
    [SerializeField] protected EffectSpawner spawner;

    protected virtual void OnEnable()
    {
        this.SpawnMuzzle();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }
    
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent.parent.GetComponentInParent<EffectSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void SpawnMuzzle()
    {
        if (this.muzzle == MuzzleCode.NoMuzzle) return;
        //EffectSpawner effectSpawner = EffectSpawnerCtrl.Instance.Spawner;
        EffectController prefab = this.spawner.PoolPrefabs.GetByName(this.muzzle.ToString());
        EffectController newEffect = this.spawner.Spawn(prefab, transform.position);
        newEffect.gameObject.SetActive(true);
    }
}