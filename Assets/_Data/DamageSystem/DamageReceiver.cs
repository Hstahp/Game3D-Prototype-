using UnityEngine;

public abstract class DamageReceiver :SaiMonoBehaviour
{
    protected int maxHp = 10;
    protected int currentHp = 10;
    protected bool isDead = false;
    [SerializeField] protected bool isImmotal = false;
    public virtual int Deduct(int hp)
    {
        if(!this.isImmotal) this.currentHp -= hp;
        if (this.IsDead())
        {
            this.OnDead();
        }
        else
        {
            this.OnHurt();
        }
        if (this.currentHp < 0) this.currentHp = 0;
        return currentHp;
    }
    protected virtual bool IsDead()
    {
        return this.isDead = this.currentHp <= 0;
    }
    protected virtual void OnDead()
    {
       //For override
    }
    protected virtual void OnHurt()
    {
       //For override
    }
}
