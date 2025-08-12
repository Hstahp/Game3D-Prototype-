using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : SaiMonoBehaviour
{
    public GameObject target;
    [SerializeField] protected EnemyController enemyController;
   
    void Start()
    {
        
    }
    void Update()
    {
    }
     void FixedUpdate()
     {
        this.Moving();
     }
     protected override void LoadComponents()
     {
        base.LoadComponents();
        this.LoadCtrl();
        this.LoadTargetMoving();
     }
    protected virtual void LoadCtrl()
    {
        if (this.enemyController != null) return;
        this.enemyController = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ":LoadCtrl", gameObject);
    }
    protected virtual void LoadTargetMoving()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("TargetMoving");
        Debug.Log(transform.name + ":LoadTargetMoving", gameObject);
    }
    protected virtual void Moving()
    {
        this.enemyController.Agent.SetDestination(target.transform.position);
    }
}
