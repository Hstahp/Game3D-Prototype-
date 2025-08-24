using UnityEngine;

public class PlayerAiming : PlayerAbstract
{
    protected float closeLookDistance = 0.6f;
    protected float farLookDistance = 1.3f;

    private void FixedUpdate()
    {
        this.Aiming();
    }

    protected virtual void Aiming()
    {
        if (InputManager.Instance.IsRightClick()) this.LookClose();
        else this.LookFar();
    }

    protected virtual void LookClose()
    {
        this.playerController.ThirdPersonCamera.defaultDistance = this.closeLookDistance;
        CrosshairPointer crosshairPointer = this.playerController.CrosshairPointer;
        this.playerController.ThirdPersonController.RotateToPosition(crosshairPointer.transform.position);

        this.playerController.ThirdPersonController.isSprinting = false;
        this.playerController.AimingRig.weight = 1;
    }

    protected virtual void LookFar()
    {
        this.playerController.ThirdPersonCamera.defaultDistance = this.farLookDistance;
        this.playerController.AimingRig.weight = 0;

    }
}