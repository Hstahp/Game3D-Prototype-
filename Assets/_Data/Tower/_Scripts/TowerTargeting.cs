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
    [SerializeField] protected List<EnemyController> enemies = new();
    protected virtual void FixedUpdate()
    {
     //   this.FindNearest();
    }
    protected virtual void OnTriggerEnter(Collider collider)
    {
        Debug.Log("OnTriggerEnter: " + collider.name);
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
        this.enemies.Add(enemyCtrl);
        //Debug.Log("AddEnemy: " + collider.name);
    }
    protected virtual void RemoveEnemy(Collider collider)
    {
        Debug.Log("RemoveEnemy: " + collider.name);
        foreach(EnemyController enemyController in this.enemies)
        {
            if(collider.transform.parent.name == enemyController.name)
            {
                this.enemies.Remove(enemyController);
                return;
            }
        }
    }
}
