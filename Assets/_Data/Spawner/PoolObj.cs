using UnityEngine;

public class PoolObj : SaiMonoBehaviour
{
    [SerializeField] protected DespawnBase despawn;
    public DespawnBase DespawnBase => despawn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawn();
    }
    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<DespawnBase>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }
}
