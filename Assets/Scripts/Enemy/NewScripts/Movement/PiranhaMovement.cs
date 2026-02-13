using UnityEngine;

public class PiranhaMovement : EnemyMovement
{
    protected override void Move()
    {
        // Move the piranha up and down in a sine wave pattern
        float newY = Mathf.Sin(Time.time * speed) * 0.5f; // Adjust amplitude as needed
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
