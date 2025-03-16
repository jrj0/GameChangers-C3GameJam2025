using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource ambianceSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip --------")]
    public AudioClip bgmReg;
    public AudioClip bgmMenu;
    public AudioClip river;
    public AudioClip ambiance;
    public AudioClip buttonSmall;
    public AudioClip buttonLarge;
    public AudioClip upgrade;
    public AudioClip closeUpgrade;
    public AudioClip openUpgrade;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    private void Start()
    {
        musicSource.clip = bgmReg;
        musicSource.Play();

        ambianceSource.clip = river;
        ambianceSource.Play();
    }

}
