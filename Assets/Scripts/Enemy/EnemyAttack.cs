using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float minTorpedoTime;
    [SerializeField] private float maxTorpedoTime;
    [SerializeField] private float minInkAttackTime;
    [SerializeField] private float maxInkAttackTime;
    [SerializeField] private GameObject torpedoPrefab;
    [SerializeField] private GameObject inkAttackPrefab;
    [SerializeField] private Transform torpedoSpawn1;
    [SerializeField] private Transform torpedoSpawn2;
    [SerializeField] private Transform torpedoSpawn3;
    [SerializeField] private Transform inkAttackSpawn;
    [SerializeField] private bool inkAttack;
    [SerializeField] private int attackAmount;

    float torpedoTimer = 0;
    float inkAttackTimer = 0;
    float torpedoInterval;
    float inkAttackInterval;

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        torpedoTimer += Time.deltaTime;

        if (torpedoTimer >= torpedoInterval)
        {
            TorpedoShoot();
            torpedoTimer = 0;
        }

        if (inkAttack)
        {
            inkAttackTimer += Time.deltaTime;
            if (inkAttackTimer >= inkAttackInterval)
            {
                InkShoot();
                inkAttackTimer = 0;
            }
        }
    }



    private void TorpedoShoot()
    {
        if (attackAmount >= 1)
        {
            GameObject torpedo1 = Instantiate(torpedoPrefab, torpedoSpawn1.position, torpedoSpawn1.rotation);
            torpedo1.layer = gameObject.layer;
        }
        if (attackAmount >= 2)
        {
            GameObject torpedo2 = Instantiate(torpedoPrefab, torpedoSpawn2.position, torpedoSpawn2.rotation);
            torpedo2.layer = gameObject.layer;
        }
        if (attackAmount >= 3)
        {
            GameObject torpedo3 = Instantiate(torpedoPrefab, torpedoSpawn3.position, torpedoSpawn3.rotation);
            torpedo3.layer = gameObject.layer;
        }
        torpedoInterval = Random.Range(minTorpedoTime, maxTorpedoTime);
    }

    private void InkShoot()
    {
        GameObject inkAttack = Instantiate(inkAttackPrefab, inkAttackSpawn.position, inkAttackSpawn.rotation);
        inkAttack.layer = gameObject.layer;
        inkAttackInterval = Random.Range(minInkAttackTime, maxInkAttackTime);
    }
}