using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : SaiMonoBehaviour where T : PoolObj
{
    [SerializeField] protected int spawnCount = 0;
    [SerializeField] protected List<T> inPoolObjs;

    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObject = Instantiate(prefab);  
        return newObject;
    }
    public virtual T Spawn(T prefab)
    {
        T newObject = Instantiate(prefab);
        //newObject.Despawn.SetSpawner(this);
        this.spawnCount++;
        this.UpdateName(prefab.transform, newObject.transform);
        return newObject;
    }
    public virtual T Spawn(T bulletPrefab, Vector3 position)
    {
        T newBullet = this.Spawn(bulletPrefab);
        newBullet.transform.position = position;
        return newBullet;
    }
    public virtual void Despawn(Transform obj)
    {
        Destroy(obj.gameObject);
    }
    public virtual void Despawn(T obj)
    {
        if(obj is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
            this.AddObjectToPool(obj);

        }
    }
    protected virtual void AddObjectToPool(T obj)
    {
        this.inPoolObjs.Add(obj);
    }
    protected virtual void UpdateName(Transform prefab, Transform newObject)
    {
        newObject.name = prefab.name + "_" + this.spawnCount;
    }
}
