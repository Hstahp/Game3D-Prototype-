using UnityEngine;

public class InventoryUI : SaiSingleton<InventoryUI>
{
    protected bool isShow = true;
    bool iSShow => isShow;
    protected override void Start()
    {
        base.Start();
        this.Show();
    }

    public virtual void Show()
    {
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
}
