using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int points;
    [SerializeField] private int enemyHealth;
    private void Update()
    {
        Destroy(gameObject, 15f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { enemyHealth--; }
        if(other.CompareTag("Bullet"))
        { enemyHealth--; }
        if (enemyHealth <= 0)
        {
           Destroy(gameObject);
        }
    }
}
