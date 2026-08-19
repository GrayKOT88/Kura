using System.Collections.Generic;
using UnityEngine;

public class FoxPool : MonoBehaviour, IObjectPool<Fox>
{
    [SerializeField] private Fox _prefabFox;    
    private int _foxPoolSize = 1;
    private Queue<Fox> _foxPool = new Queue<Fox>();

    private void Awake()
    {
        for (int i = 0; i < _foxPoolSize; i++)
        {
            ExpandPool();
        }
    }

    private void ExpandPool()
    {
        Fox fox = Instantiate(_prefabFox, transform);
        ReturnObject(fox);        
    }

    public Fox GetObject()
    {
        if( _foxPool.Count == 0)
        {
            ExpandPool();
        }
        Fox fox = _foxPool.Dequeue();
        fox.gameObject.SetActive(true);
        return fox;
    }

    public void ReturnObject(Fox obj)
    {
        obj.gameObject.SetActive(false);
        _foxPool.Enqueue(obj);
    }
}