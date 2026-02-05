using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private float shieldDamageOT = 1.5f;
    public float shieldStrenght = 5;
    private BossHealth health;
    [SerializeField] GameObject shield;
    private void Awake()
    {
        health = GetComponent<BossHealth>();
    }

    void Update()
    {
        if (health.bossHealth <= 3)
        {
            shield.SetActive(true);
            shieldDamageOT -= Time.deltaTime;
            Debug.Log("Shield on");
        }
        if (shieldStrenght <= 0)
        {
            shield.SetActive(false);
            Debug.Log("Shields Down");
        }
        
        if (shieldDamageOT <= 0)
        {
            shieldStrenght--;
            shieldDamageOT = 1.5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Hit");
            shieldStrenght--;
            Destroy(other.gameObject);
        }
    }
    #region
    // Code + Shield Shader By Xander Kortekaas 
    #endregion
}
