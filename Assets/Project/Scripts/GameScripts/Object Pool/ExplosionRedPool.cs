using System.Collections.Generic;
using UnityEngine;

public class ExplosionRedPool : MonoBehaviour, IObjectPool<ExplosionRed>
{
    [SerializeField] private ExplosionRed _prefabExplosionRed;    
    private int _explosionRedPoolSize = 5;
    private Queue<ExplosionRed> _explosionRedPool = new Queue<ExplosionRed>();

    private void Awake()
    {        
        for (int i = 0; i < _explosionRedPoolSize; i++)
        {
            ExpandPool();
        }
    }

    private void ExpandPool()
    {
        ExplosionRed explosionRed = Instantiate( _prefabExplosionRed, transform);        
        ReturnObject(explosionRed);
        explosionRed.Initialize(this);
    }

    public ExplosionRed GetObject()
    {
        if(_explosionRedPool.Count == 0)
        {
            ExpandPool();
        }
        ExplosionRed explosionRed = _explosionRedPool.Dequeue();
        explosionRed.gameObject.SetActive(true);
        return explosionRed;
    }

    public void ReturnObject(ExplosionRed obj)
    {
        obj.gameObject.SetActive(false);
        _explosionRedPool.Enqueue(obj);
    }
}