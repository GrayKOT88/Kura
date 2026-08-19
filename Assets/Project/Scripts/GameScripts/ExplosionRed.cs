using System.Collections;
using UnityEngine;

public class ExplosionRed : MonoBehaviour
{
    private IObjectPool<ExplosionRed> _pool;
    private float _returnTime = 2f;

    public void Initialize(IObjectPool<ExplosionRed> pool)
    {
        _pool = pool;
    }

    private void OnEnable()
    {
        StartCoroutine(ReturnInPool());        
    }

    private IEnumerator ReturnInPool()
    {
        yield return new WaitForSeconds(_returnTime);
        _pool.ReturnObject(this);
    }
}