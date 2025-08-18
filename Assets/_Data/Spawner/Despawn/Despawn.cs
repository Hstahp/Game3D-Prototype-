using UnityEngine;

public abstract class Despawn : SaiMonoBehaviour
{
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected float timeLife = 7.0f;
    [SerializeField] protected float currentTIme = 7.0f;

    protected virtual void FixedUpdate()
    {
        this.DespawnChecking();
    }
    public virtual void SetSpawner(Spawner spawner)
    {
        this.spawner = spawner;
      
    }
    protected virtual void DespawnChecking()
    {
        this.currentTIme -= Time.fixedDeltaTime;
        if (this.currentTIme > 0) return;
        this.spawner.Despawn(transform.parent);
        this.currentTIme = this.timeLife;
    }
 }
