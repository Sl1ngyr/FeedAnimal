using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private Sound[] musicSounds, sfxSounds;
        [SerializeField] private AudioSource musicSource, sfxSource;
        
        private void Start()
        {
            AudioListener.volume = PlayerPrefs.GetFloat(AudioConstants.GLOBAL_VOLUME_PREFS_KEY, 1);
            musicSource.volume = PlayerPrefs.GetFloat(AudioConstants.MUSIC_PREFS_KEY, 1);
            sfxSource.volume = PlayerPrefs.GetFloat(AudioConstants.SFX_PREFS_KEY, 1);
            PlayMusic(SoundType.Theme);
        }

        public void PlayMusic(SoundType soundType)
        {
            Sound sound = Array.Find(musicSounds, x => x.soundName == soundType);
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
        
        public void PlaySFX(SoundType soundType)
        {
            Sound sound = Array.Find(sfxSounds, x => x.soundName == soundType);
            sfxSource.PlayOneShot(sound.clip);
        }

        public void SetVolume(AudioSource audio, float volume)
        {
            audio.volume = volume;
        }
        
    }
}