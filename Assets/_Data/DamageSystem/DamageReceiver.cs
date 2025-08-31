using UnityEngine;

public abstract class DamageReceiver :SaiMonoBehaviour
{
    [SerializeField] protected int maxHp = 10;
    public int MaxHp => maxHp;
    [SerializeField] protected int currentHp = 10;
    public int CurrentHp => currentHp;
    protected bool isDead = false;
    [SerializeField] protected bool isImmotal = false;
    protected virtual void OnEnable()
    {
        this.OnReborn();
    }
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
    public virtual bool IsDead()
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
    protected virtual void OnReborn()
    {
        this.currentHp = this.maxHp;
    }
}
