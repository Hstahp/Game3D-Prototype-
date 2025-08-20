using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyController : PoolObj
{
    [SerializeField] protected Transform model;
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    [SerializeField] protected TowerTargetable towerTargetable;
    public TowerTargetable TowerTargetable => towerTargetable;
    [SerializeField] protected EnemyDamageReceiver enemyDamageReceiver;
    public EnemyDamageReceiver EnemyDamageReceiver => enemyDamageReceiver;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
        this.LoadModel();
        this.LoadAnimator();
        this.LoadTargetTable();
        this.LoadEnemyDamageReceiver();
    }
    protected virtual void LoadNavMeshAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        this.agent.speed = 2f;
        this.agent.angularSpeed = 200f;
        this.agent.acceleration = 150f;
        Debug.Log(transform.name + ":LoadNavMeshAgent", gameObject);
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.model.localPosition = new Vector3(0, 0, 0);
        Debug.Log(transform.name + ":LoadModel", gameObject);
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = this.model.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
    protected virtual void LoadTargetTable()
    {
        if (this.towerTargetable != null) return;
        this.towerTargetable = transform.GetComponentInChildren<TowerTargetable>();
        this.towerTargetable.transform.localPosition = new Vector3(0, 0.4f, 0);
        Debug.Log(transform.name + ": LoadTargetTable", gameObject);
    }
    protected virtual void LoadEnemyDamageReceiver()
    {
        if (this.enemyDamageReceiver != null) return;
        this.enemyDamageReceiver = GetComponentInChildren<EnemyDamageReceiver>();
        Debug.Log(enemyDamageReceiver.name + ": LoadEnemyDamageReceiver", gameObject);
    }
}
