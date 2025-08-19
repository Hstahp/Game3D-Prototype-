using UnityEngine;

public abstract class DamageReceiver :SaiMonoBehaviour
{
    protected int maxHp = 10;
    protected int currentHp = 10;
    protected bool isDead = false;
    public virtual int Deduct(int hp)
    {
        this.currentHp -= hp;
        this.IsDead();
        if (this.currentHp < 0) this.currentHp = 0;
        return currentHp;
    }
    protected virtual bool IsDead()
    {
        return this.isDead = this.currentHp <= 0;
    }
}
