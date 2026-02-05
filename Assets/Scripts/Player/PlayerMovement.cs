using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 6.6f;
    [SerializeField] private GameObject restrictionPlus;
    [SerializeField] private GameObject restrictionMin;

    private float moveSpeed;

    void Update()
    {
        Movement();
        Restriction();
    }
    #region Movement
    private void Movement()
    {
        //Movement (Roman)
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        gameObject.transform.position = new Vector3(transform.position.x + (h * moveSpeed * Time.deltaTime), transform.position.y + (v * moveSpeed * Time.deltaTime));

        //Focus mode (Roman)
        if (Input.GetKey("z"))
        {
            moveSpeed = 2.5f;
        }
        else
        {
            moveSpeed = speed;
        }
    }
    #endregion

    #region Camera restriction
    private void Restriction()
    {
        if (transform.position.x >= restrictionPlus.transform.position.x)
        {
            gameObject.transform.position = new Vector3(transform.position.x + (-moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        }
        if (transform.position.y >= restrictionPlus.transform.position.y)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + (-moveSpeed * Time.deltaTime), transform.position.z);
        }
        if (transform.position.x <= restrictionMin.transform.position.x)
        {
            gameObject.transform.position = new Vector3(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        }
        if (transform.position.y <= restrictionMin.transform.position.y)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
        }
    }
    #endregion
}
