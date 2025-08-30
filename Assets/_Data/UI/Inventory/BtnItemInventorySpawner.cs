using UnityEngine;

public class BtnItemInventorySpawner : Spawner<BtnItemInventoryCtrl>
{
    protected override void LoadPoolHolder()
    {
        if (this.poolHolder != null) return;
        this.poolHolder = transform.Find("PoolHolder");
        if (this.poolHolder == null)
        {
                
            Transform content = GameObject.Find("Content")?.transform;
            this.poolHolder = content;
           
        }
        Debug.Log(transform.name + ": LoadPoolHolder", gameObject);
    }
}
