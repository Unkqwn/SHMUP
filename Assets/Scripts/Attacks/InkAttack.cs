using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkAttack : MonoBehaviour
{
    //Is the speed
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject InkEffect;

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
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    //Makes it go faster after a second
    IEnumerator DoAfterSeconds()
    {
        yield return new WaitForSeconds(1f);

        speed = 7f;
    }

    private void OnTriggerEnter(Collider other)
    {
        InkEffect.SetActive(true);
        Destroy(gameObject);
    }
}
#region
// Made by Robin 
#endregion