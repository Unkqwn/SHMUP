using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float boundaryPadding = 0.5f;

    private Camera mainCamera;
    private Rigidbody rb;

    private Vector2 moveInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void Awake()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        ClampPlayer();
    }

    private void Move()
    {
        Vector3 pos = transform.position;
        pos.z = 0f;
        transform.position = pos;

        rb.velocity = new Vector3(moveInput.x, moveInput.y, 0f) * moveSpeed;
    }

    private void ClampPlayer()
    {
        Vector3 pos = transform.position;
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(pos);
        viewportPos.x = Mathf.Clamp(viewportPos.x, boundaryPadding, 1f - boundaryPadding);
        viewportPos.y = Mathf.Clamp(viewportPos.y, boundaryPadding, 1f - boundaryPadding);
        transform.position = mainCamera.ViewportToWorldPoint(viewportPos);
    }
}