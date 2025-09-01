using UnityEngine;

public class AttackLight : AttackAbstract
{
    protected string effectName = "Projectile2";
    [SerializeField]  protected SoundName shootSFXName = SoundName.LaserOneShoot;

    protected override void Attacking()
    {
        if (!InputManager.Instance.IsAttackLight()) return;
        AttackPoint attackPoint = this.GetAttackPoint();

        EffectController effect =  this.effectSpawner.Spawn(this.GetEffect(),  attackPoint.transform.position);

        EffectFlyAbstract effectFly = (EffectFlyAbstract)effect;
        effectFly.FlyToTarget.SetTarget(this.playerController.CrosshairPointer.transform);

        effect.gameObject.SetActive(true);
        this.SpawnSound(effectFly.transform.position);
    }

    protected virtual EffectController GetEffect()
    {
        return this.effectPrefabs.GetByName(this.effectName);
    }

    protected virtual void SpawnSound(Vector3 position)
    {
        SFXCtrl sfxPrefab = (SFXCtrl)SoundSpawnerCtrl.Instance.Prefabs.GetByName(this.shootSFXName.ToString());
        SFXCtrl newSfx = (SFXCtrl)SoundSpawnerCtrl.Instance.Spawner.Spawn(sfxPrefab, position);
        newSfx.gameObject.SetActive(true);
    }
}
