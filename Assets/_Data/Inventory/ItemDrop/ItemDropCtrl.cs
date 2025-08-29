using UnityEngine;

public class ItemDropCtrl : PoolObj
{
    [SerializeField] protected Rigidbody _rigid;
    public Rigidbody Rigidbody => _rigid;

    protected InvCodeName invCodeName = InvCodeName.Items;
    public InvCodeName InvCodeName => invCodeName;
    protected ItemCode itemCode;
    public ItemCode ItemCode => itemCode;
    protected int itemCount = 1;
    public int ItemCount=> itemCount;

    public override string GetName()
    {
        return "ItemDrop";
    }

    public virtual void SetValue(ItemCode itemCode, int itemCount)
    {
        this.itemCode = itemCode;
        this.itemCount = itemCount; 
    }

    public virtual void SetValue(ItemCode itemCode, int itemCount, InvCodeName invCodeName)
    {
        this.itemCode = itemCode;
        this.itemCount = itemCount;
        this.invCodeName = invCodeName;
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
