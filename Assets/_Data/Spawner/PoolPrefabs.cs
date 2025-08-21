using System.Collections.Generic;
using UnityEngine;

public class PoolPrefabs<T>: SaiMonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected List<T> prefabs = new();
    protected override void Awake()
    {
        base.Awake();
        this.HidePrefabs();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyPrefabs();
    }
    protected virtual void LoadEnemyPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        foreach (Transform child in transform)
        {
            T classPrefabs = child.GetComponent<T>();
            if (classPrefabs) this.prefabs.Add(classPrefabs);
        }
        Debug.Log(transform.name + ": LoadEnemyPrefabs", gameObject);
    }
    protected virtual void HidePrefabs()
    {
        foreach (T prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
    public virtual T GetRandom()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];

    }
    public  virtual T GetByName(string prefabName)
    {
        foreach (T prefab in this.prefabs)
        {
            if (prefab.name != prefabName) continue;
            return prefab;
        }
        return null;
    }
}
