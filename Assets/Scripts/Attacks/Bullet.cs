using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 7f;
    private void Start()
    {
        Destroy(gameObject, 6f);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
