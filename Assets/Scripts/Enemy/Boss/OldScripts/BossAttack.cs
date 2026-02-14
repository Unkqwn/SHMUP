using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private float minTorpedoTime;
    [SerializeField] private float maxTorpedoTime;
    [SerializeField] private float minMinigunTime;
    [SerializeField] private float maxMinigunTime;
    [SerializeField] private GameObject torpedoPrefab;
    [SerializeField] private Transform torpedoSpawn;
    [SerializeField] private GameObject minigunPrefab;
    [SerializeField] private Transform minigunSpawn;
    private Scrolling scrolling;
    float torpedoTimer = 0;
    float torpedoInterval;
    float minigunTimer = 0;
    float minigunInterval;
    [SerializeField] public bool canShoot;
    void Update()
    {
        if (canShoot)
        {
            torpedoTimer += Time.deltaTime;
            if (torpedoTimer >= torpedoInterval)
            {
                TorpedoShoot();
                torpedoTimer = 0;
            }
        }
    }
    private void TorpedoShoot()
    {
        GameObject torpedo = Instantiate(torpedoPrefab, torpedoSpawn.position, torpedoSpawn.rotation);
        torpedo.layer = gameObject.layer;
        torpedoInterval = Random.Range(minTorpedoTime, maxTorpedoTime);
    }
    private void MinigunShoot()
    {
        GameObject torpedo = Instantiate(minigunPrefab, minigunSpawn.position, minigunSpawn.rotation);
        torpedo.layer = gameObject.layer;
        minigunInterval = Random.Range(minMinigunTime, maxMinigunTime);
    }
    #region Made by
    // Code By Xander Kortekaas
    #endregion
}
