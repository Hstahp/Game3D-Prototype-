using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int currentHp = 100;
    int maxHp = 100;
    float weight = 1f;
    float minWeight = 1f;
    float maxWeight = 10f;
    bool isDead = false;
    bool isBoss = true;
    private void Reset()
    {
        this.InitData();
    }
    void OnEnable()
    {
        this.InitData();
    }
    public abstract string GetName();
    public virtual string GetObjName()
    {
        return transform.name;
        //giống return gameObj.name;
    }
    protected virtual void InitData()
    {
        this.weight = this.GetRandomWeight();
    }
    protected virtual float GetRandomWeight()
    {
        return Random.Range(this.minWeight, this.maxWeight);
    }
    private void FixedUpdate()
    {
       // this.TestClass();
    }
    void TestClass()
    {
        this.Moving();
        this.SetHp(-1);
        string logMessage = this.GetName() + ": " + this.GetCurrentHp() + " " + this.IsDead();
        Debug.Log(logMessage);
    }
    public virtual int GetMaxHp()
    {
        return this.maxHp;
    }
    public virtual int GetCurrentHp()
    {
        return this.currentHp;
    }
    public virtual void SetHp(int newHp)
    {
        this.currentHp = newHp;
    }
    public virtual float GetWeight()
    {
        return this.weight;
    }
    public virtual float GetMaxWeight()
    {
        return this.maxWeight;
    }
    public virtual float GetMinWeight()
    {
        return this.minWeight;
    }
    public virtual bool IsDead()
    {
        if (this.currentHp > 0) this.isDead = false;
        else this.isDead = true;
            return this.isDead;
    }
    public virtual bool IsBoss()
    {
        return this.isBoss;
    }
    public void Moving()
    {
        string logMessage = this.GetName() + "Moving";
        Debug.Log(logMessage);
    }
}
