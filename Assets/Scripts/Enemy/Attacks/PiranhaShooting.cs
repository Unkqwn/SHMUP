using UnityEngine;

public class PiranhaShooting : EnemyShooting
{
    protected override void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint[0].position, transform.rotation);

        EnemyTorpedo torpedo = projectile.AddComponent<EnemyTorpedo>();
        torpedo.Damage = damage;

        Destroy(projectile, projectileLifetime);
    }
}