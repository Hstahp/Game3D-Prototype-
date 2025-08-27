using UnityEngine;

public class InventoryUI : SaiSingleton<InventoryUI>
{
    protected bool isShow = true;
    bool iSShow => isShow;

    [SerializeField] protected BntItemInventory itemInventory;
    protected override void Start()
    {
        base.Start();
        this.Show();
        this.HideDefaultItemInventory();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnItemInventory();
    }

    protected virtual void LoadBtnItemInventory()
    {
        if (this.itemInventory != null) return;
        this.itemInventory = this.GetComponentInChildren<BntItemInventory>();
        Debug.Log(transform.name + ": LoadBtnItemInventory", gameObject);
    }

    public virtual void Show()
    {
        this.isShow = true;
        gameObject.SetActive(this.isShow);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
        this.isShow = false;
    }
    
    public virtual void Toggle()
    {
        if (this.isShow) this.Hide();
        else this.Show();
    }

    protected virtual void HideDefaultItemInventory()
    {
        this.itemInventory.gameObject.SetActive(false);
    }
}
