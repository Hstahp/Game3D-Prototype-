using TMPro;
using UnityEngine;

public class BtnItemInventory : ButtonAbstract
{
    [SerializeField] protected TextMeshProUGUI txtItemName;

    [SerializeField] protected TextMeshProUGUI txtItemCount;
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    [SerializeField] protected BtnItemInventoryCtrl btnItemInventoryCtrl;
    public BtnItemInventoryCtrl BtnItemInventoryCtrl => btnItemInventoryCtrl;
    protected virtual void FixedUpdate()
    {
        this.ItemUpdating();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemCount();
        this.LoadBtnItemInventoryCtrl();
    }

    protected virtual void LoadItemName()
    {
        if (this.txtItemName != null) return;
        this.txtItemName = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }

    protected virtual void LoadBtnItemInventoryCtrl()
    {
        if (this.btnItemInventoryCtrl != null) return;
        this.btnItemInventoryCtrl = transform.GetComponent<BtnItemInventoryCtrl>();
        Debug.Log(transform.name + ": LoadBtnItemInventoryCtrl", gameObject);
    }

    protected virtual void LoadItemCount()
    {
        if (this.txtItemCount != null) return;
        this.txtItemCount = transform.Find("ItemCount").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadItemCount", gameObject);
    }

    public virtual void SetItem(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }

    protected override void OnClick()
    {
        Debug.Log("Item Click");
    }

    protected virtual void ItemUpdating()
    {
        this.txtItemName.text = this.itemInventory.itemName;
        this.txtItemCount.text = this.itemInventory.itemCount.ToString();
        if (this.itemInventory.itemCount == 0) Destroy(gameObject);
        //if (this.itemInventory.itemCount == 0)
        //{
        //    if (btnItemInventoryCtrl != null) btnItemInventoryCtrl.Despawn.DoDespawn();
        //    else gameObject.SetActive(false);
        //}
    }
}
