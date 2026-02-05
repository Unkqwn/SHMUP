using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f; 
    private int pos = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
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
    #region
    // Code By Xander Kortekaas
    #endregion
}
