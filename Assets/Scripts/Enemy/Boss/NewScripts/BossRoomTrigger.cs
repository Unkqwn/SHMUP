using UnityEngine;
using Cinemachine;

public class BossRoomTrigger : MonoBehaviour
{
    [Header("Boss Settings")]
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject hpBar;

    [Header("Camera Settings")]
    [SerializeField] private CinemachineVirtualCamera bossCamera;
    private int highPriority = 20;

    private void Start()
    {
        if (hpBar == null)
        {
            hpBar = FindObjectOfType<BossHPBar>().gameObject;
        }

        hpBar.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bossCamera.Priority = highPriority;
            SpawnBoss();
            DisableScrolling(other);
        }
        else if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

    private void SpawnBoss()
    {
        EnableBossHPBar();
        GameObject boss = Instantiate(bossPrefab, transform.position, Quaternion.identity);
    }

    private void EnableBossHPBar()
    {
        hpBar.SetActive(true);
    }

    private void DisableScrolling(Collider player)
    {
        player.GetComponentInParent<Scrolling>().enabled = false;
        player.GetComponentInParent<EnemySpawning>().enabled = false;
    }
}