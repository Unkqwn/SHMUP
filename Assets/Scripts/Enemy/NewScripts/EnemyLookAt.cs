using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAt : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        if (target == null)
        {
            try
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            catch
            {
                Debug.LogError("Player not found. Please assign the target in the inspector or ensure the player has the 'Player' tag.");
            }
        }
    }

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.position);
        }
    }
}