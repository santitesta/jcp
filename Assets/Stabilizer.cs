using UnityEngine;

public class PlayerStabilizer : MonoBehaviour
{
    public float stabilizationTorque = 10f; // Torque to rotate upright
    public float stabilizationThreshold = 0f; // Always stabilize (0 threshold for constant action)
    public float uprightForce = 20f; // Force applied to help lift the body
    public float maxTiltAngle = 80f; // Maximum tilt angle before applying upright force

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Get the current rotation angle in degrees
        float angle = transform.eulerAngles.z;
        if (angle > 180f) angle -= 360f; // Convert to range [-180, 180]

        // Always apply torque to stabilize the player upright
        float torque = -angle * stabilizationTorque * Time.fixedDeltaTime;
        rb.AddTorque(torque);

        // Apply upward force if the player is tilted too far (e.g., lying on the ground)
        if (Mathf.Abs(angle) > maxTiltAngle)
        {
            Vector2 upwardForce = transform.up * uprightForce; // Apply force in the direction of the player's "up"
            rb.AddForce(upwardForce);
        }
    }
}
