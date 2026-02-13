using UnityEngine;

public class EnemyHP : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHP = 100f;
    private float currentHP;

    private void Start()
    {
        currentHP = maxHP;
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
