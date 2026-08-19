using System.Collections.Generic;
using UnityEngine;

public class FoxSpawner
{
    private IObjectPool<Fox> _foxPool;
    private List<Transform> _points;
    private Transform _player;
    private AnimalSettings _settings;

    public FoxSpawner(IObjectPool<Fox> foxPool, List<Transform> points, Transform player, AnimalSettings settings)
    {
        _foxPool = foxPool;
        _points = points;
        _player = player;
        _settings = settings;
    }

    public void SpawnFoxWave()
    {
        SpawnFox();
        if (Progress.PlayerData.saveChick >= _settings.Fifty)
        {
            SpawnFox();
        }
        if (Progress.PlayerData.saveChick >= _settings.Hundred)
        {
            SpawnFox();
        }
    }

    private void SpawnFox()
    {
        Fox fox = _foxPool.GetObject();
        fox.Initialize(_player, _points, _settings);
        fox.transform.position = _points[Random.Range(0, _points.Count)].position;
    }
}