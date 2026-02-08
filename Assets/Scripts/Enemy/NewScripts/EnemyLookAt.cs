using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAt : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        transform.LookAt(target.position);
    }
}
