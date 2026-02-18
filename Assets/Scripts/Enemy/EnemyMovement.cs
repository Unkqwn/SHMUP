using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] protected float speed;
    [SerializeField] protected float boundaryPadding = 0.1f;

    protected Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Move();

        ClampEnemy();
    }

    protected abstract void Move();

    private void ClampEnemy()
    {
        Vector3 pos = transform.position;
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(pos);
        viewportPos.y = Mathf.Clamp(viewportPos.y, boundaryPadding, 1f - boundaryPadding);
        transform.position = mainCamera.ViewportToWorldPoint(viewportPos);
    }
}
