using System.Collections;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float waitTime = 1f;

    private Rigidbody rb;
    private bool launched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(Shoot());
    }

    private void FixedUpdate()
    {
        if (launched)
        {
            rb.velocity = transform.forward * speed;
        }
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(waitTime);

        launched = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
