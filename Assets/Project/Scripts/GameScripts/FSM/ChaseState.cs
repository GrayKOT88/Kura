using UnityEngine;

public class ChaseState : State
{
    public ChaseState(Fox fox) : base(fox) { }

    public override void Enter()
    {
        fox.Agent.speed = 10f;
        fox.Animator.SetBool("isChasing", true);
    }

    public override void Update()
    {
        fox.Agent.SetDestination(fox.Player.position);

        float distance = Vector3.Distance(fox.transform.position, fox.Player.position);

        if (distance < fox.AttackRange)
        {
            fox.SetAttack();
        }
        else if (distance > fox.ChaseRange)
        {
            fox.SetIdle();
        }
    }

    public override void Exit()
    {
        fox.Agent.SetDestination(fox.transform.position);
        fox.Agent.speed = 2f;
        fox.Animator.SetBool("isChasing", false);
    }
}