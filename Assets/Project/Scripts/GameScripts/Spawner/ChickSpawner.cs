using System.Collections.Generic;
using UnityEngine;

public class ChickSpawner
{
    private IObjectPool<Chick> _chickPool;
    private List<Transform> _points;
    private Transform _player;
    private IObjectPool<ExplosionRed> _explosionRedPool;
    private Counter _counter;
    private SpawnManager _spawnManager;
    private AnimalSettings _settings;

    public ChickSpawner(IObjectPool<Chick> chickPool, List<Transform> points, Transform player,
        IObjectPool<ExplosionRed> explosionRedPool, Counter counter, SpawnManager spawnManager,
        AnimalSettings settings)
    {
        _chickPool = chickPool;
        _points = points;
        _player = player;
        _explosionRedPool = explosionRedPool;
        _counter = counter;
        _spawnManager = spawnManager;
        _settings = settings;
    }

    public void SpawnChickWave(int numberOfChicks)
    {
        for (int i = 0; i < numberOfChicks; i++)
        {
            Chick chick = _chickPool.GetObject();
            chick.Initialize(_chickPool, _player, _explosionRedPool, _settings);
            chick.transform.position = _points[Random.Range(0, _points.Count)].position;

            // Подписываемся на события
            chick.CollisionHandler.OnFoxCollision += _counter.AddEatenChicken;
            chick.CollisionHandler.OnCountCollision += _counter.AddSavedChicken;
            chick.CollisionHandler.OnFoxCollision += _spawnManager.UpdateWave;
            chick.CollisionHandler.OnCountCollision += _spawnManager.UpdateWave;
        }
    }
}