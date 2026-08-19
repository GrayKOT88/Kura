using UnityEngine;

public class ChickCollisionHandler : MonoBehaviour
{
    public event System.Action OnFoxCollision;
    public event System.Action OnCountCollision;

    private IObjectPool<Chick> _chickPool;
    private ExplosionSpawner _explosionSpawner;

    public void Initialize(IObjectPool<Chick> chickPool, ExplosionSpawner explosionSpawner)
    {
        _chickPool = chickPool;
        _explosionSpawner = explosionSpawner;        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fox"))
        {
            HandleFoxCollision();
        }
        else if (other.CompareTag("Count"))
        {
            HandleCountCollision();
        }
    }

    private void HandleFoxCollision()
    {
        _explosionSpawner.SpawnExplosion();
        OnFoxCollision?.Invoke();
        Reset();
    }

    private void HandleCountCollision()
    {                
        OnCountCollision?.Invoke();
        Reset();
    }

    private void Reset()
    {
        _chickPool.ReturnObject(GetComponent<Chick>());        
        OnFoxCollision = null;
        OnCountCollision = null;
    }
}