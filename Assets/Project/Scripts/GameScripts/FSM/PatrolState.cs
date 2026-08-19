using UnityEngine;

public class PatrolState : State
{
    private float timer;

    public PatrolState(Fox fox) : base(fox) { }

    public override void Enter()
    {
        timer = 0f;
        fox.Agent.SetDestination(GetRandomPatrolPoint());
        fox.Animator.SetBool("isPatrolling", true);
    }

    public override void Update()
    {
        timer += Time.deltaTime;

        // Проверка расстояния до игрока
        float distanceToPlayer = Vector3.Distance(fox.transform.position, fox.Player.position);
        if (distanceToPlayer < fox.ChaseRange)
        {
            fox.SetChase();
            return;
        }

        // Проверка завершения пути
        if (fox.Agent.remainingDistance <= fox.Agent.stoppingDistance)
        {
            fox.Agent.SetDestination(GetRandomPatrolPoint());
        }

        // Завершение патрулирования через заданное время
        if (timer > fox.PatrolTime)
        {
            fox.SetIdle();
        }
    }

    public override void Exit()
    {
        fox.Agent.SetDestination(fox.transform.position);
        fox.Animator.SetBool("isPatrolling", false);
    }

    private Vector3 GetRandomPatrolPoint()
    {
        return fox.PatrolPoints[Random.Range(0, fox.PatrolPoints.Count)].position;
    }
}