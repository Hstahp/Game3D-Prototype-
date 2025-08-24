using UnityEngine;

public class PlayerAbstract : SaiMonoBehaviour
{
    [SerializeField] protected PlayerController playerCtrl;
    public PlayerController PlayerController => playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    protected virtual void LoadPlayerController()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.GetComponentInParent<PlayerController>();
        Debug.Log(transform.name + ": LoadPlayerController", gameObject);
    }
}
