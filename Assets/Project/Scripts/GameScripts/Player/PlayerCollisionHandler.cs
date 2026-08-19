using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerCollisionHandler : MonoBehaviour
{
    [Inject] private IObjectPool<ExplosionRed> _explosionRedPool;
    [Inject] private IHealthSystem _playerHealth;
    [SerializeField] GameObject redOverlay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fox"))
        {
            _playerHealth.TakeDamage(1);
            StartCoroutine(RedOverlay());
            SpawnExplosion();
        }
    }

    private void SpawnExplosion()
    {
        ExplosionRed explosion = _explosionRedPool.GetObject();
        explosion.transform.position = transform.position;
    }

    IEnumerator RedOverlay()
    {
        redOverlay.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        redOverlay.SetActive(false);
    }
}