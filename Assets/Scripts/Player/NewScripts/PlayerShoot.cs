using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [Header("Torpedo Settings")]
    [SerializeField] private GameObject torpedoPrefab;
    [SerializeField] private float torpedoLifetime = 5f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float shootCooldown = 0.5f;

    [SerializeField] private float initialForce = 20f;

    [Header("References")]
    [SerializeField] private Transform attackSpawn;

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject projectile = Instantiate(torpedoPrefab, attackSpawn.position, attackSpawn.rotation);

            Torpedo torpedo = projectile.GetComponent<Torpedo>();
            if (torpedo == null)
            {
                torpedo = projectile.AddComponent<Torpedo>();
            }
            torpedo.Damage = damage;

            Rigidbody torpedoRb = projectile.GetComponent<Rigidbody>();
            if (torpedoRb != null)
            {
                torpedoRb.AddForce(transform.forward * initialForce, ForceMode.Impulse);
            }

            Destroy(projectile, torpedoLifetime);
        }
    }
}
