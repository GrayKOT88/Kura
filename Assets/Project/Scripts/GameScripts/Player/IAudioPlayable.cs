using UnityEngine;

public interface IAudioPlayable
{
    void PlaySound(AudioClip clip, float volume = 1f);
}