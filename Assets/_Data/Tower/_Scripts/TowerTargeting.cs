using NUnit;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class TowerTargeting : SaiMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigid;
    [SerializeField] protected EnemyController nearest;
    public EnemyController Nearest => nearest;
    [SerializeField] protected List<EnemyController> enemies = new();
    protected virtual void FixedUpdate()
    {
        this.FindNearest();
        this.RemoveDeadEnemy();
    }
    protected virtual void OnTriggerEnter(Collider collider)
    {
        this.AddEnemy(collider);
    }
    protected virtual void OnTriggerExit(Collider collider)
    {
        this.RemoveEnemy(collider);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 5f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (this.rigid != null) return;
        this.rigid = GetComponent<Rigidbody>();
        this.rigid.useGravity = false;
         Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }
    
    protected virtual void AddEnemy(Collider collider)
    {
        if (collider.name != Const.TOWER_TARGETABLE) return;
        EnemyController enemyCtrl = collider.transform.parent.GetComponent<EnemyController>();
        
        if (enemyCtrl.EnemyDamageReceiver.IsDead()) return;
        this.enemies.Add(enemyCtrl);
    }
    protected virtual void RemoveEnemy(Collider collider)
    {
        foreach(EnemyController enemyController in this.enemies)
        {
            if(collider.transform.parent == enemyController.transform)
            {
                this.enemies.Remove(enemyController);
                return;
            }
        }
    }
    protected virtual void FindNearest()
    {
        float nearestDistance = Mathf.Infinity;
        float enemyDistance;
        foreach(EnemyController enemyController in this.enemies)
        {
            enemyDistance = Vector3.Distance(transform.position, enemyController.transform.position);
            if(enemyDistance < nearestDistance)
            {
                nearestDistance = enemyDistance;
                this.nearest = enemyController;
            }
        }
    }
    protected virtual void RemoveDeadEnemy()
    {
        foreach(EnemyController enemyCtrl in this.enemies){
            if (enemyCtrl.EnemyDamageReceiver.IsDead())
            {
                if(enemyCtrl == this.nearest) this.nearest = null;  
                this.enemies.Remove(enemyCtrl);
                return;
            }
        }
    }
}
