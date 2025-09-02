using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeMusic : SliderAbstract
{
    protected override void OnSliderValueChangeds(float value)
    {
        SoundManager.Instance.VolumeMusicUpdating(value);
    }
}
