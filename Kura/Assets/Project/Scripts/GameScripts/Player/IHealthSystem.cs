public interface IHealthSystem
{
    event System.Action OnDamageTaken;
    event System.Action OnGameOver;
    void TakeDamage(int damage);
    void ResetHealth();
}
