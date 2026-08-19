using UnityEngine;
using Zenject;

public class Counter : MonoBehaviour
{
    [Inject] private ScoreManager _scoreManager;
    [Inject] private AchievementManager _achievementManager;
    [Inject] private ScoreSaver _scoreSaver;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _pointSound;    

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        LoadInitialData();
    }

    private void LoadInitialData()
    {
        _scoreManager.AddChickens(Progress.PlayerData.saveChick);
        _scoreManager.AddFoxes(Progress.PlayerData.eatenChick);
        _achievementManager.UpdateMedals(Progress.PlayerData.saveChick);
    }

    public void AddSavedChicken()
    {
        _scoreManager.AddChickens(1);
        _achievementManager.UpdateMedals(_scoreManager.CountChickens);
        _scoreSaver.SaveScores(_scoreManager.CountChickens, _scoreManager.CountFoxes);
        _audioSource.PlayOneShot(_pointSound);
    }

    public void AddEatenChicken()
    {
        _scoreManager.AddFoxes(1);
        _scoreSaver.SaveScores(_scoreManager.CountChickens, _scoreManager.CountFoxes);
    }
}
