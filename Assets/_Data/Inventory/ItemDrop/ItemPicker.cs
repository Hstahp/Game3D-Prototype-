using UnityEngine;
[RequireComponent(typeof(SphereCollider))]  
public class ItemPicker : SaiMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;

    protected void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent == null) return;
        ItemDropCtrl itemDropCtrl = other.transform.parent.GetComponent<ItemDropCtrl>();
        if(itemDropCtrl ==  null) return;
        itemDropCtrl.Despawn.DoDespawn();
        Debug.Log(other.name, other.gameObject);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.5f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }
}
