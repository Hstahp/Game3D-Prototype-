using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerController : SaiMonoBehaviour
{
    [SerializeField] protected vThirdPersonController thirdPersonCtrl;
    public vThirdPersonController ThirdPersonController => thirdPersonCtrl;


    [SerializeField] protected vThirdPersonCamera thirdPersonCamera;
    public vThirdPersonCamera ThirdPersonCamera => thirdPersonCamera;

    [SerializeField] protected CrosshairPointer crosshairPointer;
    public CrosshairPointer CrosshairPointer => crosshairPointer;

    [SerializeField] protected Rig aimingRig;
    public Rig AimingRig => aimingRig;

    [SerializeField] protected Weapons weapons;
    public Weapons Weapons => weapons;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadThirdPersonCtrl();
        this.LoadThirdPersonCamera();
        this.LoadCrosshairPointer();
        this.LodaAimingRig();
        this.LoadWeapons();
    }

    protected virtual void LoadCrosshairPointer()
    {
        if (this.crosshairPointer != null) return;
        this.crosshairPointer = this.transform.GetComponentInChildren<CrosshairPointer>();
        Debug.Log(transform.name + ": LoadCrosshairPointer", gameObject);
    }
    protected virtual void LoadThirdPersonCtrl()
    {
        if (this.thirdPersonCtrl != null) return;
        this.thirdPersonCtrl = GetComponent<vThirdPersonController>();
        Debug.Log(transform.name + ": LoadThirPersonCtrl", gameObject);
    }


    protected virtual void LoadThirdPersonCamera()
    {
        if (this.thirdPersonCamera != null) return;
        this.thirdPersonCamera = GameObject.FindAnyObjectByType<vThirdPersonCamera>();
        this.thirdPersonCamera.rightOffset = 0.6f;
        this.thirdPersonCamera.defaultDistance = 1.3f;
        this.thirdPersonCamera.height = 1.3f;
        this.thirdPersonCamera.yMinLimit = -40f;
        this.thirdPersonCamera.yMaxLimit = 40f;
        Debug.Log(transform.name + ": LoadThirdPersonCamera", gameObject);
    }

    protected virtual void LodaAimingRig()
    {
        if (this.aimingRig != null) return;
        //this.aimingRig = this.transform.GetComponentInChildren<Rig>();
        //this.aimingRig = this.transform.Find("Model").GetComponentInChildren<Rig>();
        this.aimingRig = transform.Find("Model").Find("AimingRig").GetComponent<Rig>();
        Debug.Log(transform.name + ": LodaAimingRig", gameObject);
    }

    protected virtual void LoadWeapons()
    {
        if(this.weapons != null) return;    
        this.weapons = transform.GetComponentInChildren<Weapons>();
        Debug.Log(transform.name + ": LoadWeapons", gameObject);
    }
}