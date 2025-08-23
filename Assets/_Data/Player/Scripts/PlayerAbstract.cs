using UnityEngine;

public class PlayerAbstract : SaiMonoBehaviour
{
    [SerializeField] protected PlayerController playerController;
    public PlayerController PlayerController => playerController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController = transform.GetComponentInParent<PlayerController>();
        Debug.Log(transform.name + ": LoadPlayerController", gameObject);
    }
}
