using UnityEngine;
using UnityEngine.AI;

public class ChickMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private Transform _target;
    private AnimalSettings _settings;    

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    public void Initialize(Transform target, AnimalSettings settings)
    {
        _target = target;
        _settings = settings;
    }

    private void Update()
    {
        if (_target == null) return;

        float distance = Vector3.Distance(transform.position, _target.position);

        if (distance >= _settings.FollowDistance)
        {
            StandStill();
        }
        else if (distance < _settings.FollowDistance && distance > _settings.StopDistance)
        {
            _agent.isStopped = false;
            _agent.SetDestination(_target.position);
            _animator.SetFloat("Speed_f", 1);
        }
        else if (distance <= _settings.StopDistance)
        {
            StandStill();
        }
    }

    private void StandStill()
    {
        _agent.isStopped = true;
        _animator.SetFloat("Speed_f", 0);
    }
}
