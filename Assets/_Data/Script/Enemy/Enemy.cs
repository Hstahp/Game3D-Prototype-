using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int currentHp = 100;
    int maxHp = 100;
    float weight = 2.5f;
    string enemyName = "Enemy";
    bool isDead = false;
    bool isBoss = true;
    //EnemyHead head1 = new EnemyHead();
    //EnemyHeart heart = new EnemyHeart();
    public abstract string GetName();
    private void FixedUpdate()
    {
        this.TestClass();
    }
    void TestClass()
    {
        this.Moving();
        this.SetHp(-1);
        string logMessage = this.GetName() + ": " + this.GetCurrentHp() + " " + this.IsDead();
        Debug.Log(logMessage);
    }
 
    public virtual int GetCurrentHp()
    {
        return this.currentHp;
    }
    public virtual void SetHp(int newHp)
    {
        this.currentHp = newHp;
    }
    float GetWeight()
    {
        return this.weight;
    }
    public virtual bool IsDead()
    {
        if (this.currentHp > 0) this.isDead = false;
        else this.isDead = true;
            return this.isDead;
    }
    bool IsBoss()
    {
        return this.isBoss;
    }
    public void Moving()
    {
        string logMessage = this.GetName() + "Moving";
        Debug.Log(logMessage);
    }
}
