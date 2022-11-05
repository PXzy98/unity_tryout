using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof (Slider))]
public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string sliderName;
    public Slider slider
    {
        get { return GetComponent<Slider>(); }
    }
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        //audioMixer.GetFloat("Volume");
        audioMixer.SetFloat("Volume", volume);
    }

    private void Start()
    {
        SetVolume(slider.value);
        slider.onValueChanged.AddListener(delegate
        {
            SetVolume(slider.value);
        });
    }
}
