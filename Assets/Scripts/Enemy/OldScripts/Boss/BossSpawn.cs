using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject spawnCondition;
    private Coroutine coroutine;

    // start zet de timer aan 
    private void Update()
    {
        if (Player == null)
        {
            return;
        }
        if (Player.transform.position.x >= spawnCondition.transform.position.x)
        {
            if (coroutine == null)
            {
                coroutine = StartCoroutine(BossTimer());
            }
        }
    }


    // boss timer die na een tijd de bos spawned
    IEnumerator BossTimer()
    {
        yield return new WaitForSeconds(1);
        Instantiate(boss, transform.position, boss.transform.rotation);
    }
    #region
    // Code By Xander Kortekaas
    #endregion
}
