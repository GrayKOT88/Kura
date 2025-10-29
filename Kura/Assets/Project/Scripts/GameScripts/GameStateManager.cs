using UnityEngine;
using Zenject;

public class GameStateManager : MonoBehaviour
{
    [Inject] private ScoreManager _scoreManager;
    [Inject] private AchievementManager _achievementManager;
    [Inject] private IHealthSystem _playerHealth;

    private void Start()
    {
        _playerHealth.OnGameOver += OnGameOver;
    }

    private void OnGameOver()
    {
        ResetSessionProgress();
    }

    public void ResetSessionProgress()
    {
        // Сбрасываем текущую сессию
        Progress.PlayerData.eatenChick = 0;
        Progress.PlayerData.saveChick = 0;
        Progress.SaveData();

        // Сбрасываем UI
        _scoreManager.ResetScores();
        _achievementManager.UpdateMedals(0);
    }

    public void ResetAllProgress()
    {
        // Полный сброс (включая рекорды)
        Progress.PlayerData.ResetData();
        Progress.SaveData();
    }
}