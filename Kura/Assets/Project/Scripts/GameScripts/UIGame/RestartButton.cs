using UnityEngine;
using Zenject;

public class RestartButton : MonoBehaviour
{    
    [Inject] private IHealthSystem _playerHealth;
    [Inject] private PlayerMovement _playerMovement;    
    [Inject] private SpawnManager _spawnManager;
    [Inject(Id = "Player")] private Transform _player;

    public void Restart()
    {
        Time.timeScale = 1;

        // —брасываем позицию игрока
        _player.transform.position = new Vector3(-40, _player.transform.position.y, -60);
        _player.transform.rotation = Quaternion.identity;
        
        // —брасываем состо€ние игрока
        _playerHealth.ResetHealth();
        _playerMovement.SetGameOver(false);
        
        // ѕерезапускаем спавн
        _spawnManager.ResetSpawning();
    }
}