using UnityEngine;

public abstract class EnemyShooting : MonoBehaviour
{
    [Header("Shooting Parameters")]
    [SerializeField] protected Transform[] firePoint;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float fireRate;

    [Header("Projectile Parameters")]
    [SerializeField] protected float damage;
    [SerializeField] protected float projectileLifetime;

    protected float shootDelay;

    protected virtual void Update()
    {
        shootDelay -= Time.deltaTime;

        if (shootDelay <= 0)
        {
            Shoot();
            shootDelay = 1f / fireRate;
        }
    }

    protected abstract void Shoot();
}