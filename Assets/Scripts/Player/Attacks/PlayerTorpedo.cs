using UnityEngine;

public class PlayerTorpedo : MonoBehaviour
{
    public float Damage { get; set; } = 10f;

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null && !other.CompareTag("Player"))
        {
            damageable.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}