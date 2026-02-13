using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float speed;

    private void Update()
    {
        Move();
    }

    protected abstract void Move();
}
