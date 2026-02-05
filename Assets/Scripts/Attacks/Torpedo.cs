using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    [SerializeField] private float speed = 7f;


    void Start()
    {
        //Activates the speed change
        StartCoroutine(DoAfterSeconds());
        //Destroys the object
        Destroy(gameObject, 4.5f);
    }

    void Update()
    {
        //Movement of the torpedo
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    //Makes it go faster after a second
    IEnumerator DoAfterSeconds()
    {
        yield return new WaitForSeconds(1f);

        speed = 11.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
