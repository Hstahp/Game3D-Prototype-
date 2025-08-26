using UnityEngine;

public class InventoryUI : SaiMonoBehaviour
{
    protected bool isShow = true;
    bool iSShow => isShow;
    protected override void Start()
    {
        base.Start();
        this.Hide();
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
}
