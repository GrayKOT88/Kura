using System.Collections.Generic;
using UnityEngine;

public class ChickPool : MonoBehaviour, IObjectPool<Chick>
{
    [SerializeField] private Chick _prefabChick;    
    private int _chickPoolSize = 10;
    private Queue<Chick> _chickPool = new Queue<Chick>();

    private void Awake()
    {
        for (int i = 0; i < _chickPoolSize; i++)
        {
            ExpandPool();
        }        
    }

    private void ExpandPool()
    {
        Chick chick = Instantiate(_prefabChick, transform);
        ReturnObject(chick);        
    }

    public Chick GetObject()
    {
        if (_chickPool.Count == 0)
        {
            ExpandPool();
        }
        Chick chick = _chickPool.Dequeue();
        chick.gameObject.SetActive(true);
        return chick;
    }

    public void ReturnObject(Chick chick)
    {
        chick.gameObject.SetActive(false);        
        _chickPool.Enqueue(chick);
    }
}