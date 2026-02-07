using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject torpedoPrefab;
    [SerializeField] private float torpedoLifetime = 5f;
    [SerializeField] private Transform attackSpawn;

    [SerializeField] private float initialForce = 20f;

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject torpedo = Instantiate(torpedoPrefab, attackSpawn.position, attackSpawn.rotation);
            Rigidbody torpedoRb = torpedo.GetComponent<Rigidbody>();
            torpedoRb.AddForce(transform.forward * initialForce, ForceMode.Impulse);

            Destroy(torpedo, torpedoLifetime);
        }
    }
}
