using UnityEngine;

public class GanfaulMAureMoving : EnemyMoving
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.pathName = "path_0";
    }
}