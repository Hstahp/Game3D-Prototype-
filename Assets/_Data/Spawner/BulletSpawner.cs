using UnityEngine;

public class BulletSpawner : Spawner
{
    //Method overloading
    public virtual Bullet Spawn(Bullet prefab)
    {
        Bullet newObject = Instantiate(prefab);
        newObject.Despawn.SetSpawner(this);
        return newObject;
    }
    public virtual Bullet Spawn(Bullet bulletPrefab, Vector3 position)
    {
        Bullet newBullet = this.Spawn(bulletPrefab);
        newBullet.transform.position = position;
        return newBullet;
    }
}
