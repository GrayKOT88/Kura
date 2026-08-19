using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fox : MonoBehaviour
{    
    private AnimalSettings _settings;
    private NavMeshAgent _agent;
    private Animator _animator;
    private Transform _player;
    private List<Transform> _patrolPoints;
    private StateMachine _stateMachine;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _stateMachine = new StateMachine();  // Инициализация машины состояний
        _stateMachine.ChangeState(new IdleState(this));
    }

    public void Initialize(Transform player, List<Transform> patrolPoints, AnimalSettings settings)
    {
        _player = player;
        _patrolPoints = patrolPoints;
        _settings = settings;
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    // Свойства для доступа из состояний
    public NavMeshAgent Agent => _agent;
    public Animator Animator => _animator;
    public Transform Player => _player;
    public List<Transform> PatrolPoints => _patrolPoints;
    public float AttackRange => _settings.AttackRange;
    public float ChaseRange => _settings.ChaseRange;
    public float PatrolTime => _settings.PatrolTime;
    public float IdleTime => _settings.IdleTime;

    // Методы для изменения состояния
    public void SetIdle() => _stateMachine.ChangeState(new IdleState(this));
    public void SetChase() => _stateMachine.ChangeState(new ChaseState(this));
    public void SetAttack() => _stateMachine.ChangeState(new AttackState(this));
    public void SetPatrol() => _stateMachine.ChangeState(new PatrolState(this));
}