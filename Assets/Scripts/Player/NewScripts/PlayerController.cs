using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0f;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    private void FixedUpdate()
    {
        transform.Translate(scrollSpeed * Time.fixedDeltaTime, 0f, 0f, Space.World);
    }
}
