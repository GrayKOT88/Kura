using UnityEngine;

public class PlayerAudio : MonoBehaviour, IAudioPlayable
{    
    private AudioSource _audioSource;    

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();        
    }

    public void PlaySound(AudioClip clip, float volume = 1)
    {
        _audioSource.PlayOneShot(clip, volume);
    }
}