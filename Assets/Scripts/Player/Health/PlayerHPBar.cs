using UnityEngine;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] private RectTransform hpBar;

    public void SetHealth(float currentHealth)
    {
        if (hpBar == null)
        {
            return;
        }

        float healthPercent = currentHealth / 100f;
        hpBar.localScale = new Vector3(healthPercent, 1f, 1f);
    }
}