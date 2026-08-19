using UnityEngine;

[CreateAssetMenu(fileName = "AnimalSettings", menuName = "Game/AnimalSettings")]
public class AnimalSettings : ScriptableObject
{
    [Header("Player")]
    public int MaxHealth = 3;
    public float Speed = 11;
    public float YRange = 0.03f;
    [Space]
    [Header("Fox")]
    public float AttackRange = 1f;
    public float ChaseRange = 25f;
    public float PatrolTime = 180f;
    public float IdleTime = 5f;
    [Space]
    public int Fifty = 50;
    public int Hundred = 100;
    [Space]
    [Header("Chick")]
    public float FollowDistance = 10f;
    public float StopDistance = 1f;   
    [Space]
    [Header("Medal")]
    public int Bronze = 20;
    public int Silver = 50;
    public int Gold = 100;
}
