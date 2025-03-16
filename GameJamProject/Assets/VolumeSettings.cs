using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider mySlider;
    // Use this for initialization

    public void SetMusicVolume()
    {
        float volume = mySlider.value;
        myMixer.SetFloat("music", volume);
    }
}
