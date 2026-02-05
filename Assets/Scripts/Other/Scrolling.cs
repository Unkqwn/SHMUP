using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject waypoint;
    [SerializeField] public bool canMove = true;

    private BossAttack canAttack;

    private void Start()
    {
        StartCoroutine(DoAfterSeconds());

        canAttack = GameObject.Find("Boss").GetComponent<BossAttack>();
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (transform.position.x >= waypoint.transform.position.x)
        {
            canMove = false;
        }
        if (canMove == false)
        {
            speed = 0;
        }

        canAttack.canShoot = !canMove;
    }
    IEnumerator DoAfterSeconds()
    {
        yield return new WaitForSeconds(1f);

        speed = 5.5f;
    }
    #region
    //Code By Robin van den Berg
    #endregion
}
