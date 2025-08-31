using UnityEngine;

public abstract class SliderHp : SliderAbstract
{
    [SerializeField] protected Transform fill;
    protected void FixedUpdate()
    {
        this.UpdateSlider();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFill();
    }

    protected virtual void UpdateSlider()
    {
        this.slider.value = this.GetValue();
        if (this.slider.value != 0) return;
        this.fill.gameObject.SetActive(false);
    }

    protected virtual void LoadFill()
    {
        if (this.fill != null) return;
        this.fill = transform.Find("Fill Area").Find("Fill");
    }

    protected abstract float GetValue();
}
