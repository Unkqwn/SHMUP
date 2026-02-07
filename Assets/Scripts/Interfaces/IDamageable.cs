/// <summary>
/// Implement this interface on components that can take damage.
/// </summary>
public interface IDamageable
{
    void TakeDamage(float amount);
}