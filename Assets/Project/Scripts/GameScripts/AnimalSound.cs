using UnityEngine;

public class AnimalSound : MonoBehaviour
{
    [SerializeField] AudioClip _audioClip;
    private AudioSource playerAudio;
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {       
        if (collision.gameObject.CompareTag("Player"))
        {
            playerAudio.PlayOneShot(_audioClip, 1);
        }
    }
}