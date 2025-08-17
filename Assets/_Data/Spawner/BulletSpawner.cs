using UnityEngine;

public class BulletSpawner : Spawner
{
    public virtual Bullet Spawn(Bullet prefab)
    {
        Bullet newObject = Instantiate(prefab);
        return newObject;
    }
    public virtual Bullet Spawn(Bullet bulletPrefab, Vector3 position)
    {
        Bullet newBullet = this.Spawn(bulletPrefab);
        newBullet.transform.position = position;
        return newBullet;
    }
}
