using UnityEngine;

public class KrakenShooting : EnemyShooting
{
    protected override void Shoot()
    {
        foreach (Transform point in firePoint)
        {
            GameObject projectile = Instantiate(projectilePrefab, point.position, point.rotation);

            EnemyTorpedo torpedo = projectile.AddComponent<EnemyTorpedo>();
            torpedo.Damage = damage;

            Destroy(projectile, projectileLifetime);
        }
    }
}