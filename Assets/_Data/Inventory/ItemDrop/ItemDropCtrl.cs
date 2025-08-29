using UnityEngine;

public class ItemDropCtrl : PoolObj
{
    [SerializeField] protected Rigidbody _rigid;
    public Rigidbody Rigidbody => _rigid;
    public override string GetName()
    {
        return "ItemDrop";
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigid != null) return;
        this._rigid = GetComponent<Rigidbody>();
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }
}
