using UnityEngine;

public class AttackLight : AttackAbstract
{
    protected string effectName = "Fire1";
    protected override void Attacking()
    {
        if (!InputManager.Instance.IsAttackLight()) return;
        AttackPoint attackPoint = this.GetAttackPoint();

        EffectController effect =  this.effectSpawner.Spawn(this.GetEffect(),  attackPoint.transform.position);
        effect.gameObject.SetActive(true);
        Debug.Log("Light Attack");
    }

    protected virtual EffectController GetEffect()
    {
        return this.effectPrefabs.GetByName(this.effectName);
    }
}
