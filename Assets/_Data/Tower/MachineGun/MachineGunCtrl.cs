using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MachineGunCtrl : TowerController
{
    public override string GetName()
    {
        return TowerCode.MachineGun.ToString();
    }
}
