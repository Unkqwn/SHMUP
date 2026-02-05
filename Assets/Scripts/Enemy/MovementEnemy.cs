using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private int pos;

    void Update()
    {
        movement();
    }
    void movement()
    {
        if (pos == 1)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (transform.position.y <= -8.5f)
            {
                pos--;
            }
        }

        if (pos == 0)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (transform.position.y >= -2.6f)
            {
                pos++;
            }
        }
    }
}
