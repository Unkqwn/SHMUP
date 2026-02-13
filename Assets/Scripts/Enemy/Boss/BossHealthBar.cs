using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    Slider _healthSlider;
    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
    }
    public void SetMaxHealth(float maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = maxHealth;
    }

    public void SetHealth(float maxHealth)
    {
        _healthSlider.value = maxHealth;
    }
    #region
    //Code By Roman Agterberg
    #endregion
}
