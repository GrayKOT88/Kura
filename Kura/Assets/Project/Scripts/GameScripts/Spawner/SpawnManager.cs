using System.Collections.Generic;
using UnityEngine;
using Zenject;

public partial class SpawnManager : MonoBehaviour
{
    [Inject] private IObjectPool<Fox> _foxPool;
    [Inject] private IObjectPool<Chick> _chickPool;
    [Inject] private IObjectPool<ExplosionRed> _explosionRedPool;
    [Inject(Id = "Player")] private Transform _player;
    [Inject(Id = "SpawnPoints")] private List<Transform> _points;
    [Inject] private Counter _counter;
    [Inject] private AnimalSettings _settings;

    private int _chickCount;
    private int _waveNumber = 4;
    private ChickSpawner _chickSpawner;
    private FoxSpawner _foxSpawner;
   
    void Start()
    {
        _chickSpawner = new ChickSpawner(_chickPool, _points, _player, _explosionRedPool, _counter, this, _settings);
        _foxSpawner = new FoxSpawner(_foxPool, _points, _player, _settings);
        _foxSpawner.SpawnFoxWave();
        StartWave();
    }

    public void UpdateWave()
    {
        _chickCount--;
        if (_chickCount == 0)
        {
            _waveNumber++;
            StartWave();
        }
    }

    public void ResetSpawning()
    {
        _chickCount = 0;
        _waveNumber = 4;
        StartWave();
    }

    private void StartWave()
    {
        _chickSpawner.SpawnChickWave(_waveNumber);
        _chickCount = _waveNumber; ;
    }
}