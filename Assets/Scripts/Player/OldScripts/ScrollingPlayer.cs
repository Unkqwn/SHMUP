using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject waypoint;
    [SerializeField] public bool canMove = true;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        if (transform.position.x >= waypoint.transform.position.x)
        {
            canMove = false;
        }
        if (canMove == false)
        {
            speed = 0;
        }
    }
}
