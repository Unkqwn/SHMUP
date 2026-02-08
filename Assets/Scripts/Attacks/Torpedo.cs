using UnityEngine;

public class Torpedo : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }
}