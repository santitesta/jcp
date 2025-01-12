using UnityEngine;

public class BallKicker : MonoBehaviour
{
    public float kickForce = 2000f; // Adjust this value for desired kick strength

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is colliding with the ball
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                // Calculate direction from player to ball
                Vector2 direction = collision.contacts[0].point - (Vector2)transform.position;
                direction = direction.normalized;

                // Apply force to the ball
                ballRb.AddForce(direction * kickForce);
            }
        }
    }
}
