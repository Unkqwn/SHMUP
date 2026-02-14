using UnityEngine;

public class EnemyHP : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHP = 100f;
    protected float currentHP;
    private float lifetime = 5f;

    private void Start()
    {
        currentHP = maxHP;

        Destroy(gameObject, lifetime);
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
