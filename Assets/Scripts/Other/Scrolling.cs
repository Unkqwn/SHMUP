using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;

    private void FixedUpdate()
    {
        transform.Translate(scrollSpeed * Time.fixedDeltaTime, 0f, 0f, Space.World);
    }
}