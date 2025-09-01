using UnityEngine;

public class AttackHeavy : AttackAbstract
{
    protected string effectName = "Projectile3";
    protected float timer = 0;
    protected float delay = 0.1f;
    [SerializeField] protected SoundName shootSFXName = SoundName.LaserOneShoot;

    protected override void Attacking()
    {
        if (!InputManager.Instance.IsAttackHeavy()) return;

        this.timer += Time.deltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;
        AttackPoint attackPoint = this.GetAttackPoint();

        EffectController effect = this.effectSpawner.Spawn(this.GetEffect(), attackPoint.transform.position);

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
        SFXCtrl newSFX = SoundManager.Instance.CreateSFX(this.shootSFXName);
        newSFX.transform.position = position;   
        newSFX.gameObject.SetActive(true);
    }
}
