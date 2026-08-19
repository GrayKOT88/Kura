using UnityEngine;
using Zenject;

public class PlayerHealth : MonoBehaviour, IHealthSystem
{
    [Inject] private AnimalSettings _settings;
    [Inject] private HealthBarScript _healthBar;
    [Inject(Id = "GameOverImage")] private GameObject _gameOverImage;
    [Inject(Id = "PauseButton")] private GameObject _pauseButton;
    private int currentHealth;
    private bool isGameOver = false;
    public event System.Action OnGameOver;
    public event System.Action OnDamageTaken;

    private void Start()
    {
        ResetHealth();
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver) return;

        currentHealth -= damage;
        _healthBar.SetHealth(currentHealth);
        OnDamageTaken?.Invoke();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void ResetHealth()
    {
        currentHealth = _settings.MaxHealth;
        _healthBar.SetHealth(currentHealth);
        isGameOver = false;
        _gameOverImage.SetActive(false);
        _pauseButton.SetActive(true);
    }

    private void GameOver()
    {
        isGameOver = true;
        _gameOverImage.SetActive(true);
        _pauseButton.SetActive(false);
        OnGameOver?.Invoke();
    }
}