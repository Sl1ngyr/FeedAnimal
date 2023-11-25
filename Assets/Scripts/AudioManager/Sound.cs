using UnityEngine;

public enum SoundType 
{
    Eat,
    Hit,
    Theme,
}

namespace DefaultNamespace
{
    [System.Serializable]
    public class Sound
    {
        public SoundType soundName;
        public AudioClip clip;
    }
}