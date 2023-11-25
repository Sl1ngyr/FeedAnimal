using System;
using UnityEngine;
using UnityEngine.UI;
using DefaultNamespace;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider globalSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Button exitButton;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    
    private void Start()
    {
        globalSlider.value = AudioListener.volume;
        musicSlider.value = musicSource.volume;
        sfxSlider.value = sfxSource.volume;
        exitButton.onClick.AddListener(SaveAudioData);
        globalSlider.onValueChanged.AddListener(OnGlobalValueChanged);
        musicSlider.onValueChanged.AddListener(OnMusicValueChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXValueChanged);
    }

    private void OnDestroy()
    {
        globalSlider.onValueChanged.RemoveListener(OnGlobalValueChanged);
        musicSlider.onValueChanged.RemoveListener(OnMusicValueChanged);
        sfxSlider.onValueChanged.RemoveListener(OnSFXValueChanged);
    }

    private void SaveAudioData()
    {
        PlayerPrefs.SetFloat(AudioConstants.GLOBAL_VOLUME_PREFS_KEY, globalSlider.value);
        PlayerPrefs.SetFloat(AudioConstants.MUSIC_PREFS_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(AudioConstants.SFX_PREFS_KEY, sfxSlider.value);
    }

    private void OnGlobalValueChanged(float value)
    {
        AudioListener.volume = value;
    }

    private void OnMusicValueChanged(float value)
    {
        audioManager.SetVolume(musicSource, value);
    }
    
    private void OnSFXValueChanged(float value)
    {
        audioManager.SetVolume(sfxSource, value);
    }
    
}