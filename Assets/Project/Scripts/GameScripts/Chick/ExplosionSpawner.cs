using UnityEngine;

public class ExplosionSpawner : MonoBehaviour
{
    private IObjectPool<ExplosionRed> _explosionRedPool;
    public void Initialize(IObjectPool<ExplosionRed> explosionRedPool)
    {        
        _explosionRedPool = explosionRedPool;        
    }

    public void SpawnExplosion()
    {
        ExplosionRed explosionRed = _explosionRedPool.GetObject();
        explosionRed.transform.position = transform.position;
    }
}