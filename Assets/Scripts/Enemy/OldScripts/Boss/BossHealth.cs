using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField] public float bossHealth;
    [SerializeField] BossHealthBar _healthbar;
    public bool bossDead = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            bossHealth--;
            _healthbar.SetHealth(bossHealth);
        }
        if (bossHealth <= 0)
        {
            Destroy(gameObject);
            bossDead = true;
            Win();
        }
    }
    public void Win()
    {
        SceneManager.LoadScene("WinScreen");

    }
    #region
    //Code By Roman Agterberg
    #endregion
}
