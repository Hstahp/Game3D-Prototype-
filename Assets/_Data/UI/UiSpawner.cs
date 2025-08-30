using UnityEngine;

public class UISpawner<T> : Spawner<T> where T : PoolObj
{
    [SerializeField] protected RectTransform uiParent;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        //this.LoadUIParent();
    }

    //protected virtual void LoadUIParent()
    //{
    //    if (this.uiParent != null) return;
    //    this.uiParent = GetComponentInChildren<RectTransform>();
    //    Debug.Log(transform.name + ": LoadUIParent", gameObject);
    //}

    protected override void LoadPoolPrefabs()
    {
        if (this.poolPrefabs != null) return;
        this.poolPrefabs = transform.GetComponent<PoolPrefabs<T>>();
        Debug.Log(transform.name + ": LoadPoolPrefabs", gameObject);
    }

    //public override T Spawn(T prefab)
    //{
    //    T newObject = this.GetObjFromPool(prefab);
    //    if (newObject == null)
    //    {
    //        newObject = Instantiate(prefab);
    //        this.spawnCount++;
    //        this.UpdateName(prefab.transform, newObject.transform);
    //    }

    //    if (this.uiParent != null)
    //        newObject.transform.SetParent(this.uiParent, false);
    //    else if (this.poolHolder != null)
    //        newObject.transform.SetParent(this.poolHolder, false);

    //    return newObject;
    //}
}
