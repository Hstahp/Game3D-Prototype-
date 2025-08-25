using UnityEngine;

public class AttackPoint : SaiMonoBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.046f, 0.507f, -0.01f);
    }
}
