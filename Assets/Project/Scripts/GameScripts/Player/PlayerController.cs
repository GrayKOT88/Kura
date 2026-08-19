using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip _damageSound;
    [Inject] private PlayerMovement _playerMovement;
    [Inject] private IHealthSystem _playerHealth;
    [Inject] private  IAudioPlayable _playerAudio;
   
    private void Awake()
    {       
        _playerHealth.OnGameOver += () => _playerMovement.SetGameOver(true);
        _playerHealth.OnDamageTaken += () => _playerAudio.PlaySound(_damageSound,1);
    }
}