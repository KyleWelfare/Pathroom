using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSliderValues : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    void Start()
    {
        musicSlider.value = AudioSettings.instance.musicVolume;
        sfxSlider.value = AudioSettings.instance.sfxVolume;
    }
}
