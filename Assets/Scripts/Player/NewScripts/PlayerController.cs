using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }
}
