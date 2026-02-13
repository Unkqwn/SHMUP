using UnityEngine;

public class SharkShooting : EnemyShooting
{
    protected override void Shoot()
    {
        foreach (Transform point in firePoint)
        {
            GameObject projectile = Instantiate(projectilePrefab, point.position, transform.rotation);

            EnemyTorpedo torpedo = projectile.AddComponent<EnemyTorpedo>();
            torpedo.Damage = damage;

            Destroy(projectile, projectileLifetime);
        }
    }
}