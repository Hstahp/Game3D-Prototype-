using UnityEngine;

public class LevelManager : SaiSingleton<LevelManager>
{
    [SerializeField] protected PlayerLevel level;
    public PlayerLevel Level => level;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerLevel();
    }

    protected virtual void LoadPlayerLevel()
    {
        if (this.level != null) return;
        this.level = GetComponentInChildren<PlayerLevel>();
        Debug.Log(transform.name + ": LoadPlayerLevel", gameObject);
    }
  
}
