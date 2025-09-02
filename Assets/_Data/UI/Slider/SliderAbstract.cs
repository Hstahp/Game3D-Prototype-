using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class SliderAbstract : SaiMonoBehaviour
{
    [SerializeField] protected Slider slider;

    protected override void Start()
    {
        base.Start();
        this.slider.onValueChanged.AddListener(OnSliderValueChangeds);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.Log(transform.name + ": LoadSlider", gameObject);
    }

    protected virtual void OnSliderValueChangeds(float value)
    {
        //
    }
}
