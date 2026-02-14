using UnityEngine;

public class PlayerHP : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHP = 100f;
    [SerializeField] private PlayerHPBar hpBar;

    private float currentHP;

    private void Start()
    {
        currentHP = maxHP;

        if (hpBar == null)
        {
            try
            {
                hpBar = FindObjectOfType<PlayerHPBar>();
            }
            catch
            {
                Debug.LogWarning("PlayerHPBar not found in the scene.");
            }
        }
        if (hpBar != null)
        {
            hpBar.SetHealth(currentHP);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        if (hpBar != null)
        {
            hpBar.SetHealth(currentHP);
        }

        if (currentHP <= 0)
        {
            GameManager.Instance.GameOver();
        }

    }
}