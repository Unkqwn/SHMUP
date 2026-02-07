using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private Scrolling move;
    private float Timer;
    [SerializeField] private GameObject Piranha;
    [SerializeField] private GameObject Kraken;
    [SerializeField] private GameObject Shark;
    private Coroutine coroutine;
    void Start()
    {
        move = FindObjectOfType<Scrolling>();

    }

    void FixedUpdate()
    {
        time();
    }

    void time()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(mEnemyTimer());
        }
    }

    void placeEnemy()
    {
        // This code makes a random enemy spawn
        int mRandomSpawnChance = Random.Range(1, 11);
        if (mRandomSpawnChance >= 3)
        {
            int mRandomEnemy = Random.Range(1, 4);
            if (mRandomEnemy == 1)
            {
                Instantiate(Piranha, transform.position, Piranha.transform.rotation);
            }
            if (mRandomEnemy == 2)
            {
                Instantiate(Shark, transform.position, Shark.transform.rotation);
            }
            if (mRandomEnemy == 3)
            {
                Instantiate(Kraken, transform.position, Kraken.transform.rotation);
            }
        }
    }

    IEnumerator mEnemyTimer()
    {
        // This code starts the function to place the enemies
        while (true)
        {
            placeEnemy();
            yield return new WaitForSeconds(10);
        }
    }
}
