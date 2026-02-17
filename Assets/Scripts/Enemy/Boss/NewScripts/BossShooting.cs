using UnityEngine;

public class BossShooting : EnemyShooting
{
    [Header("Basic Attack")]
    [SerializeField] private float basicFireRate = 1f;

    [Header("Minigun Attack")]
    [SerializeField] private float minigunDuration = 3f;
    [SerializeField] private float minigunDamage = 2.5f;
    [SerializeField] private float minigunChance = 0.2f;

    [Header("Minigun Burst Settings")]
    [SerializeField] private int bulletsPerBurst = 5;
    [SerializeField] private float burstFireRate = 20f;
    [SerializeField] private float burstCooldown = 0.5f;

    private int burstShotsRemaining;
    private bool isInBurst;

    private bool isMinigunActive;
    private float minigunTimer;

    protected override void Update()
    {
        base.Update();

        if (isMinigunActive)
        {
            minigunTimer -= Time.deltaTime;

            if (minigunTimer <= 0)
            {
                isMinigunActive = false;
            }
        }
    }


    protected override void Shoot()
    {
        if (isMinigunActive)
        {
            MinigunLogic();
        }
        else
        {
            BasicLogic();
        }
    }

    private void BasicLogic()
    {
        if (Random.value < minigunChance)
        {
            isMinigunActive = true;
            minigunTimer = minigunDuration;

            StartNewBurst();

            shootDelay = 0f;
            return;
        }

        fireRate = basicFireRate;
        BasicAttack();
    }


    private void StartNewBurst()
    {
        isInBurst = true;
        burstShotsRemaining = bulletsPerBurst;
        fireRate = burstFireRate;
    }

    private void MinigunLogic()
    {
        if (!isInBurst)
        {
            // Waiting between bursts
            fireRate = 1f / burstCooldown;
            StartNewBurst();
            return;
        }

        MinigunAttack();
        burstShotsRemaining--;

        if (burstShotsRemaining <= 0)
        {
            isInBurst = false;
            fireRate = 1f / burstCooldown;
        }
    }


    private void BasicAttack()
    {
        var projectile = Instantiate(projectilePrefab, firePoint[0].position, firePoint[0].rotation);
        var torpedo = projectile.AddComponent<EnemyTorpedo>();
        torpedo.Damage = damage;

        Destroy(projectile, projectileLifetime);
    }

    private void MinigunAttack()
    {
        var projectile = Instantiate(projectilePrefab, firePoint[1].position, firePoint[1].rotation);
        var torpedo = projectile.AddComponent<EnemyTorpedo>();
        torpedo.Damage = minigunDamage;

        Destroy(projectile, projectileLifetime);
    }
}