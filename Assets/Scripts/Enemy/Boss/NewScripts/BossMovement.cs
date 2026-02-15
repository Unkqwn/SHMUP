using UnityEngine;

public class BossMovement : EnemyMovement
{
    [Header("Boss Movement Settings")]
    [SerializeField] private float movementPatternChangeTime = 5f;

    [Header("Piranha Movement Settings")]
    [SerializeField] private float minDirectionChangeTime = 0.2f;
    [SerializeField] private float maxDirectionChangeTime = 1.2f;

    private float currentDirection = 1f;
    private float directionTimer;

    [Header("Shark Movement Settings")]
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.3f;
    private float velocityY;

    private enum MovementType
    {
        Piranha,
        Shark,
        Kraken
    }

    private MovementType currentMovement;

    private void Awake()
    {
        if (target == null)
        {
            try
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            catch
            {
                Debug.LogWarning("Player not found for BossMovement. Please assign a target.");
            }
        }

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    protected override void Move()
    {
        Vector3 pos = transform.position;
        pos.z = 0f;
        transform.position = pos;

        if (movementPatternChangeTime <= 0f)
        {
            PickNewMovement();
            movementPatternChangeTime = Random.Range(5f, 10f);
        }
        else
        {
            movementPatternChangeTime -= Time.deltaTime;
        }

        switch (currentMovement)
        {
            case MovementType.Piranha:
                ReplicatePiranha();
                break;

            case MovementType.Shark:
                ReplicateShark();
                break;

            case MovementType.Kraken:
                ReplicateKraken();
                break;
        }
    }

    private void PickNewMovement()
    {
        float pattern = Random.value;

        if (pattern < 0.33f)
        {
            currentMovement = MovementType.Piranha;
        }
        else if (pattern < 0.66f)
        {
            currentMovement = MovementType.Shark;
        }
        else
        {
            currentMovement = MovementType.Kraken;
        }
    }

    private void ReplicatePiranha()
    {
        directionTimer -= Time.deltaTime;

        if (directionTimer <= 0f)
        {
            PickNewDirection();
        }

        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPos.y >= 1f - boundaryPadding)
        {
            currentDirection = -1f;
        }
        else if (viewportPos.y <= 0f + boundaryPadding)
        {
            currentDirection = 1f;
        }

        Vector3 pos = transform.position;
        pos.y += currentDirection * speed * Time.deltaTime;
        transform.position = pos;
    }

    private void ReplicateShark()
    {
        float newY = Mathf.SmoothDamp(transform.position.y, target.position.y, ref velocityY, smoothTime, speed);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void ReplicateKraken()
    {
        Vector3 pos = transform.position;

        pos.y += currentDirection * speed * Time.deltaTime;
        transform.position = pos;

        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPos.y >= 1f - boundaryPadding)
        {
            currentDirection = -1f;
        }
        else if (viewportPos.y <= 0f + boundaryPadding)
        {
            currentDirection = 1f;
        }
    }

    private void PickNewDirection()
    {
        currentDirection = Random.value > 0.5f ? 1f : -1f;
        directionTimer = Random.Range(minDirectionChangeTime, maxDirectionChangeTime);
    }
}