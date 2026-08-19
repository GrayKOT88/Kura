using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Header("Настройки")]
    [SerializeField] private AnimalSettings _animalSettings;
    [SerializeField] private PlayerDataSO _playerData;
    [Header("Пулы")]
    [SerializeField] private FoxPool _foxPool;
    [SerializeField] private ChickPool _chickPool;
    [SerializeField] private ExplosionRedPool _explosionRedPool;
    [Header("Объекты")]
    [SerializeField] private Transform _player;
    [SerializeField] private List<Transform> _spawnPoints;
    [Header("UI")]
    [SerializeField] private GameObject _gameOverImage;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private TextMeshProUGUI _counterTextFox;
    [SerializeField] private GameObject _gold;
    [SerializeField] private GameObject _silver;
    [SerializeField] private GameObject _bronze;
    [Header("Классы")]
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private AchievementManager _achievementManager;
    [SerializeField] private ScoreSaver _scoreSaver;
    [SerializeField] private Counter _counter;
    [SerializeField] private HealthBarScript _healthBar;

    public override void InstallBindings()
    {
        //  ScriptableObject
        Container.BindInstance(_animalSettings);
        Container.BindInstance(_playerData);
        //  пулы
        Container.Bind<IObjectPool<Chick>>().FromInstance(_chickPool);
        Container.Bind<IObjectPool<Fox>>().FromInstance(_foxPool);
        Container.Bind<IObjectPool<ExplosionRed>>().FromInstance(_explosionRedPool);
        // Объекты
        Container.BindInstance(_player).WithId("Player");        
        Container.BindInstance(_spawnPoints).WithId("SpawnPoints");
        // UI
        Container.BindInstance(_gameOverImage).WithId("GameOverImage");
        Container.BindInstance(_pauseButton).WithId("PauseButton");
        Container.BindInstance(_counterText).WithId("CounterText");
        Container.BindInstance(_counterTextFox).WithId("CounterTextFox");
        Container.BindInstance(_gold).WithId("Gold");
        Container.BindInstance(_silver).WithId("Silver");
        Container.BindInstance(_bronze).WithId("Bronze");
        // Классы
        Container.BindInstance(_scoreManager);
        Container.BindInstance(_achievementManager);
        Container.BindInstance(_scoreSaver);
        Container.BindInstance(_counter);
        Container.BindInstance(_healthBar);
        // Player-зависимостей
        Container.BindInterfacesAndSelfTo<PlayerHealth>().FromComponentInHierarchy().AsSingle();        
        Container.BindInterfacesAndSelfTo<PlayerMovement>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerAudio>().FromComponentInHierarchy().AsSingle();
        // Регистрация класса SpawnManager
        Container.BindInterfacesAndSelfTo<SpawnManager>().FromComponentInHierarchy().AsSingle();
    }
}