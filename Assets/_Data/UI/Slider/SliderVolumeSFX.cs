using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeSFX : SliderAbstract
{
    protected override void OnSliderValueChangeds(float value)
    {
        SoundManager.Instance.VolumeSFXUpdating(value);
    }
}
