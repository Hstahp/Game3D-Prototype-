using UnityEngine;

public abstract class Spawner : SaiMonoBehaviour
{
    public virtual Bullet Spawn(Bullet prefab)
    {
        Bullet newObject = Instantiate(prefab);
        return newObject;
    }
    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObject = Instantiate(prefab);  
        return newObject;
    }
}
